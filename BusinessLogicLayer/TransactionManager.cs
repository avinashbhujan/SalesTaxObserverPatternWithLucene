using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SalesTaxObserverPattern
{
    public class TransactionManager
    {
        private IList<Observer> observers;

        private List<Product> products;

        public List<Product> getProducts()
        {
            return products;
        }


        public TransactionManager(IList<Observer> observers, List<Product> products)
        {
            this.observers = observers;
            this.products = products;
        }

        public void setProducts(List<Product> products)
        {
            this.products = products;
            notifyAllObservers();
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update();
            }
        }

        public void ReadTransactionsFromFile(StreamReader filepath)
        {

            string productOrigin;
            string productName, productType = string.Empty;
            int numberOfProducts = 0;
            double productPrice = 0.0;
            string line;
            bool lastItem = false;
            StringBuilder productFullName = new StringBuilder();

            //C:\Users\vbhujan\Documents\ProductsInput3.txt
            //1 imported box of biscuits at 10.00
            //1 imported bottle of perfume at 47.50

            try
            {
                while ((line = filepath.ReadLine()) != null)
                {
                    Product product = new Product();
                    List<string> productLine = line.Split(null).ToList();

                    productOrigin = "Local";

                    numberOfProducts = int.Parse(productLine[0]);
                    productLine.Remove(productLine[0]);

                    for (int i = 0; i < productLine.Count; i++)
                    {
                        if (productLine[i].Equals("imported"))
                        {
                            productOrigin = "Imported";
                        }
                        else if (lastItem == true)
                        {
                            productPrice = Convert.ToDouble(productLine[i]);
                        }
                        else if (!productLine[i].Equals("at") && !productLine[i].Equals("imported"))
                        {
                            productFullName.Append(productLine[i] + " ");
                        }
                        else if (productLine[i].Equals("at"))
                        {
                            lastItem = true;
                        }
                    }

                    productName = productFullName.ToString();
                    productFullName.Clear();

                    if (productName.Contains("book"))
                    {
                        productType = "Book";
                    }
                    else if (productName.Contains("biscuit"))
                    {
                        productType = "Food";
                    }
                    else if (productName.Contains("pills"))
                    {
                        productType = "Medical";
                    }
                    else
                    {
                        productType = "Normal";
                    }

                    product.Name = productName;
                    product.Origin = productOrigin;
                    product.Price = productPrice;
                    product.Type = productType;
                    product.NumberOfProducts = numberOfProducts;


                    numberOfProducts = 0;
                    productName = string.Empty;
                    productOrigin = string.Empty;
                    productPrice = 0.0;
                    productType = string.Empty;
                    lastItem = false;

                    products.Add(product);

                }
                notifyAllObservers();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
        }

        internal void ReadTransactionsFromConsole()
        {
            string productName, productOrigin = "";
            string productType = "";
            int numberOfProducts = 0;
            double productPrice = 0.0;

            Console.WriteLine("Enter number of Products to be processed: ");
            numberOfProducts = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfProducts; i++)
            {
                Product product = new Product();

                Console.WriteLine("Enter Product Name: ");
                productName = Console.ReadLine();

                product.Name = productName;

                Console.WriteLine("Enter Product Price: ");
                productPrice = Convert.ToDouble(Console.ReadLine());
                product.Price = productPrice;

                Console.WriteLine("Enter Product Type: ");
                productType = Console.ReadLine();
                product.Type = productType;

                Console.WriteLine("Enter Product Origin: ");
                productOrigin = Console.ReadLine();
                product.Origin = productOrigin;

                products.Add(product);

                notifyAllObservers();
            }
        }
    }
}
