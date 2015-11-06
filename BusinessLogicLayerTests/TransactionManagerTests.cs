using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxObserverPattern.Tests
{
    [TestFixture]
    public class TransactionManagerTests
    {
        [Test]
        public void ReadTransactionsFromFile_Valid_ObserverNeverCalled()
        {

            var mockObserver = new Moq.Mock<Observer>();
            List<Observer> ol = new List<Observer>();
            ol.Add(mockObserver.Object);
            List<Product> listOfProducts = new List<Product>();
            TransactionManager tm = new TransactionManager(ol, listOfProducts);


            tm.ReadTransactionsFromFile(new StreamReader(@"C:\Users\vbhujan\Documents\Cart.txt"));


            mockObserver.Verify(o => o.update(), Times.Never);
        }

        [Test]
        public void ReadTransactionsFromFile_Valid_ObserverCalledOnce()
        {

            var mockObserver = new Moq.Mock<Observer>();
            List<Observer> ol = new List<Observer>();
            ol.Add(mockObserver.Object);
            List<Product> listOfProducts = new List<Product>();
            listOfProducts.Add(new Product());
            TransactionManager tm = new TransactionManager(ol, listOfProducts);


            tm.ReadTransactionsFromFile(new StreamReader(@"C:\Users\vbhujan\Documents\Cart.txt"));


            mockObserver.Verify(o => o.update(), Times.Once);
        }
    }
}