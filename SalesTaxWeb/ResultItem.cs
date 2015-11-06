using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesTaxWeb
{
    public class ResultItem
    {
        public ResultItem()
        {
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Origin { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int NumberOfProducts { get; set; }
    }
}