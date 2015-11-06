using System;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxObserverPattern
{
    class Program
    {
        //private static readonly string filePath = @"C:\Users\vbhujan\Documents\Transactions.txt";

        static void Main(string[] args)
        {
            List<Observer> listOfObservers = new List<Observer>();
            List<Product> listOfProducts = new List<Product>();

            TransactionManager tm = new TransactionManager(listOfObservers, listOfProducts);

            ProductTotalizer transactionTotals =  new ProductTotalizer(tm);

            //ProductIndexer productIndexer = new ProductIndexer(tm);

            tm.ReadTransactionsFromFile(new StreamReader(@"C:\Users\vbhujan\Documents\Cart.txt")); //Reads file and notifies observers

            Console.WriteLine("Total Sales: " + transactionTotals.totalSales);
            Console.WriteLine("Total Tax: " + transactionTotals.totalTax);
            Console.WriteLine("Total Amount: " + transactionTotals.totalAmount);

            Console.ReadLine();

        }
    }
}
