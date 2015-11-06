using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesTaxWeb
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LuceneManager productIndexer = (LuceneManager)Session[Constants.ProductIndexer];

            IndexSearcher searcher = productIndexer.searcher;
            QueryParser parser = productIndexer.parser;

            if (searcher == null)
            {
                throw new CorruptIndexException("Corrupted Index. Cannot proceed further.");
            }
            
            TopDocs hits = null;
            Query query = parser.Parse(txtSearch.Text);
            hits = searcher.Search(query, 200);

            int resultsCount = hits.ScoreDocs.Length;
            lblResult.Text = "Found results " + resultsCount;

            List<ResultItem> resultsList = new List<ResultItem>();

            for (int ixResult = 0; ixResult < resultsCount; ixResult++)
            {
                int docId = hits.ScoreDocs[ixResult].Doc;
                Document docResult = searcher.Doc(docId);
                var ri = new ResultItem();
                ri.ID = docId;
                ri.Name = docResult.Get("Name");
                ri.Origin = docResult.Get("Origin");
                ri.Price = Double.Parse(docResult.Get("Price"));
                resultsList.Add(ri);
            }

            DataList1.DataSource = resultsList;
            DataList1.DataBind();
        }
    }
}