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
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SalesTaxWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            InitializeObserver();
        }

        private void InitializeObserver()
        {
            TransactionManager tmgr = new TransactionManager();
            LuceneManager productIndexer = new LuceneManager(tmgr);
            ProductTotalizer productTotalizer = new ProductTotalizer(tmgr);

            Session[Constants.TransactionManager] = tmgr;
            Session[Constants.ProductIndexer] = productIndexer;
            Session[Constants.ProductTotalizer] = productTotalizer;


        }
    }
}