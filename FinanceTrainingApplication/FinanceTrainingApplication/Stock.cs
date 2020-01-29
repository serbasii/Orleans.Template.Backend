using System;
using System.Collections.Generic;
using System.Text;
using static FinanceTrainingApplication.Enums;

namespace FinanceTrainingApplication
{
    public class Stock
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime PurchasedDate { get; set; }
        public StockAction Action { get; set; }
    }
}