using System;
using System.Collections.Generic;
using static FinanceTrainingApplication.Enums;

namespace FinanceTrainingApplication
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public decimal PurchasedStockPrice { get; set; } = 0.0M;
        public List<Stock> Stocks = new List<Stock>();

        public void CalculateFinance(string ticker, decimal dropStockPercent, decimal salePercent, decimal stockPrice, decimal purchaseStockPrice)
        {
            if (PurchasedStockPrice == 0.0M)
            {
                InitialStockPurchase(ticker, stockPrice, purchaseStockPrice);
                return;
            }

            if (stockPrice < PurchasedStockPrice)
            {
                if (DropStock(stockPrice, CalculateActionPrice(dropStockPercent)))
                {
                    UpdateStockActions(ticker, stockPrice, StockAction.Drop);
                }
            }
            else
            {
                if (SaleStock(stockPrice, CalculateActionPrice(salePercent)))
                {
                    UpdateStockActions(ticker, stockPrice, StockAction.Sale);
                    PurchasedStockPrice = 0.0M;
                }
            }
        }

        public void InitialStockPurchase(string ticker, decimal stockPrice, decimal purchaseStockPrice)
        {
            if (stockPrice <= purchaseStockPrice)
            {
                PurchasedStockPrice = stockPrice;
                UpdateStockActions(ticker, stockPrice, StockAction.InitalPurchase);

                return;
            }

            UpdateStockActions(ticker, stockPrice, StockAction.Pass);
        }

        private void UpdateStockActions(string ticker, decimal stockPrice, StockAction stockAction)
        {
            Stocks.Add(new Stock { Name = ticker, Value = stockPrice, PurchasedDate = DateTime.Now, Action = stockAction });
        }

        public decimal CalculateActionPrice(decimal percent)
        {
            return PurchasedStockPrice * percent;
        }

        public bool DropStock(decimal stockPrice, decimal dropAmount)
        {
            if (stockPrice <= (PurchasedStockPrice - dropAmount))
            {
                return true;
            }

            return false;
        }

        public bool SaleStock(decimal stockPrice, decimal saleAmount)
        {
            if (stockPrice >= (PurchasedStockPrice + saleAmount))
            {
                return true;
            }

            return false;
        }
    }
}