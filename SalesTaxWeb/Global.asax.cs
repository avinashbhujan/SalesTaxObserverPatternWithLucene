using SalesTaxObserverPattern;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

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
            TransactionManager tmgr = new TransactionManager(new List<Observer>() ,new List<Product>());
            LuceneManager productIndexer = new LuceneManager(tmgr);
            ProductTotalizer productTotalizer = new ProductTotalizer(tmgr);

            Session[Constants.TransactionManager] = tmgr;
            Session[Constants.ProductIndexer] = productIndexer;
            Session[Constants.ProductTotalizer] = productTotalizer;


        }
    }
}