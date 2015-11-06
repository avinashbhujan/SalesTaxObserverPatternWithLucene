using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SalesTaxObserverPattern;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxWeb
{
    public class LuceneManager : Observer
    {
        public QueryParser parser = null;
        public IndexSearcher searcher = null;

        string[] fields = new string[] {"Name","Origin","Price"};

        public LuceneManager(TransactionManager tm)
        {
            this.transactionManager = tm;
            this.transactionManager.attach(this);
        }

        public override void update()
        {
            List<Product> products = transactionManager.getProducts();

            //delete index and recreate it
            InitializeForLucene(products);
            
        }

        private void InitializeForLucene(List<Product> products)
        {
            string strIndexDir = @"C:\Index";
            var dirInfo = new System.IO.DirectoryInfo(strIndexDir);
            Lucene.Net.Store.Directory directory = FSDirectory.Open(dirInfo);

            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);

            searcher = null;
            int count = 0;

            while (searcher == null && count < 3)
            {
                try
                {
                    count++;
                    if (count > 1)
                    {
                        //Console.WriteLine(String.Format("Attempting to search index once again...(Attempt #{0})", count));
                    }
                    searcher = new IndexSearcher(directory, readOnly: true);
                }
                catch (FileNotFoundException ex)
                {
                    //Console.WriteLine(ex.Message);
                    //Console.WriteLine(String.Format("Rebuilding the index... (Attempt #{0})", count));
                    RebuildIndex(directory, analyzer,products);
                }
            }

            if (searcher == null)
            {
                throw new CorruptIndexException(String.Format("Corrupted Index. {0} Attempts made at Reconstruction. Giving Up!", count));
            }
            else
            {
                parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fields, analyzer);
            }
        }

        private static void RebuildIndex(Lucene.Net.Store.Directory directory, Analyzer analyzer, List<Product> products)
        {
            IndexWriter writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.LIMITED);
            writer.DeleteAll();
            writer.Commit();
            foreach (Product p in products) // Add Documents to the Index.
            {
                AddDocumentToIndex(p, writer);
            }
            writer.Optimize();
            writer.Commit();
            writer.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="writer"></param>
        private static void AddDocumentToIndex(Product p, IndexWriter writer)
        {
            Document doc = new Document();
            doc.Add(new Field("Name",
                               p.Name,
                               Field.Store.YES,
                               Field.Index.ANALYZED,
                               Lucene.Net.Documents.Field.TermVector.YES
                               )
                     );
            doc.Add(new Field("Origin",
                               p.Origin.ToString(),
                               Field.Store.YES,
                               Field.Index.ANALYZED,
                               Lucene.Net.Documents.Field.TermVector.YES
                               )
                     );
            doc.Add(new Field("Price",
                               p.Price.ToString(),
                               Field.Store.YES,
                               Field.Index.ANALYZED,
                               Lucene.Net.Documents.Field.TermVector.YES
                               )
                     );
            writer.AddDocument(doc);
        }
    }
}