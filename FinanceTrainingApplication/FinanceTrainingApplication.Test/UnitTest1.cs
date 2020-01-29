using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FinanceTrainingApplication.Test
{
    [TestClass]
    public class Testing
    {
        private Program _application;

        public Testing()
        {
            _application = new Program();
        }

        [TestMethod]
        public void InitalPurchaseFalse()
        {
            _application.PurchasedStockPrice = 0.0M;

            _application.CalculateFinance("MSFT", .03M, .05M, 334.45M, 100);
            Assert.AreEqual(_application.PurchasedStockPrice, 0.0M);
            Assert.AreEqual(_application.Stocks[0].Action, Enums.StockAction.Pass);

            //10 per queue move to next
            const int MAX_SIZE = 10;
            var listContainer = new List<object[]>();
            listContainer.Add(new object[MAX_SIZE]);
            int currentQueue = -1;
            int arrayCounter = 0;

            //list addition
            //foreach (object[] queue in listContainer)
            //    currentQueue++;
            //    if (arrayCounter < (MAX_SIZE - 1))
            //    {
            //        listContainer[0][arrayCounter] = new object();
            //        arrayCounter++;
            //    }
            //    else
            //    {
            //        listContainer.Add(new object[MAX_SIZE]); //create new queue

            //        //place logic to detemine if new queue has room as well

            //        for (int i = 0; i < MAX_SIZE; i++) //FIFO - bottom on old queue
            //        {
            //            if (listContainer[currentQueue][i] != null) //Top of new queue
            //            {
            //                for (int z = 0; z < 10; z++)
            //                {
            //                    if (listContainer[listContainer.Count - 1][z] != null) //add to the top of the stack
            //                    {
            //                        listContainer[listContainer.Count - 1][z] = listContainer[currentQueue][i];
            //                        listContainer[currentQueue][i] = null;
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        arrayCounter++;
            //    }
        }

        [TestMethod]
        public void InitalPurchaseTrue()
        {
            _application.PurchasedStockPrice = 0.0M;

            _application.CalculateFinance("MSFT", .03M, .05M, 100, 100);
            Assert.AreEqual(_application.PurchasedStockPrice, 100);
            Assert.AreEqual(_application.Stocks[0].Action, Enums.StockAction.InitalPurchase);
            Assert.AreEqual(_application.Stocks[0].Value, 100);
        }

        [TestMethod]
        public void PurchaseFalse()
        {
            _application.PurchasedStockPrice = 100M;

            _application.CalculateFinance("MSFT", .03M, .05M, 99, 100);
            Assert.AreEqual(_application.PurchasedStockPrice, 100);
        }

        [TestMethod]
        public void DropTrue()
        {
            _application.PurchasedStockPrice = 150M;

            _application.CalculateFinance("MSFT", .5M, .05M, 50, 100);
            Assert.AreEqual(_application.Stocks[0].Value, 50);
            Assert.AreEqual(_application.Stocks[0].Action, Enums.StockAction.Drop);
        }

        [TestMethod]
        public void SaleTrue()
        {
            _application.PurchasedStockPrice = 150M;

            _application.CalculateFinance("MSFT", .5M, .5M, 225, 100);
            Assert.AreEqual(_application.Stocks[0].Value, 225);
            Assert.AreEqual(_application.Stocks[0].Action, Enums.StockAction.Sale);
        }

        [TestMethod]
        public void PurchaseFalse2()
        {
            _application.PurchasedStockPrice = 150M;

            _application.CalculateFinance("MSFT", 1.3M, .5M, 151, 100);
            Assert.AreEqual(_application.PurchasedStockPrice, 150);
        }
    }
}