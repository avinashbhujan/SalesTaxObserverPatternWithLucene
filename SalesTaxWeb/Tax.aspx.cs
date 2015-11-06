using SalesTaxObserverPattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesTaxWeb
{
    public partial class Tax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Session["Path"] = txtPath.Text;

            TransactionManager tmgr = (TransactionManager)Session[Constants.TransactionManager];
            ProductTotalizer pt = (ProductTotalizer)Session[Constants.ProductTotalizer];

            tmgr.ReadTransactionsFromFile(new StreamReader(txtPath.Text));

            lblTotalSales.Text = String.Format("Total Sales:{0} ", pt.totalSales);
            lblTotalTax.Text = String.Format("Total Tax:{0} ", pt.totalTax);
            lblTotalAmount.Text = String.Format("Total Amount:{0} ", pt.totalAmount);
        }
    }
}