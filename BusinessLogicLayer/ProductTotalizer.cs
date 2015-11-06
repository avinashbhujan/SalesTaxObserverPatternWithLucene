using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxObserverPattern
{
    public class ProductTotalizer : Observer
    {

        public double totalSales { get; private set; }
        public double totalTax { get; private set; }
        public double totalAmount
        {
            get
            {
                return totalSales + totalTax;
            }
        }

        public ProductTotalizer(TransactionManager tm)
        {
            this.transactionManager = tm;
            this.transactionManager.attach(this);
        }

        public override void update()
        {
            List<Product> products = transactionManager.getProducts();
            this.totalSales = products.Sum(p => p.Price);
            this.totalTax = products.Sum(p => p.Tax);
        }
    }
}