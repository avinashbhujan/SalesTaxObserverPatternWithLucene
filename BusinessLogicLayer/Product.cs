using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxObserverPattern
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public string Origin { get; set; }

        public int NumberOfProducts { get; set; }

        public string Description { get; set; }

        public double Tax
        {
            get
            {
                double tax = 0.0;

                if (!(Type.Equals("Book") || Type.Equals("Food") || Type.Equals("Medical")))
                {
                    tax += Price * 0.1;
                    if (Origin.Equals("Imported"))
                    {
                        tax += Price * 0.05;
                    }
                }
                else
                {
                    if (Origin.Equals("Imported"))
                    {
                        tax += Price * 0.05;
                    }
                }

                return tax;
            }
        }
    }
}
