using System;
using System.IO;

namespace SalesTaxObserverPattern
{
    class Program
    {
        //private static readonly string filePath = @"C:\Users\vbhujan\Documents\Transactions.txt";

        static void Main(string[] args)
        {
            TransactionManager tm = new TransactionManager();

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
