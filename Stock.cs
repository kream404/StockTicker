using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StockTicker
{
    class Stock
    {
        //class attributes
        private string stockSymbol;
        private string stockName;
        private DateTime timestamp;
        double stockValue;
        

        //empty constructor as the stocks are constructed when parsing the string and assigning variables
        public Stock()
        {
        }

        public Stock(string stockSymbol, string stockName, DateTime timestamp, double stockValue)
        {
            this.StockSymbol = stockSymbol;
            this.StockName = stockName;
            this.Timestamp = timestamp;
            this.StockValue = stockValue;
        }

        public string StockSymbol { get => stockSymbol; set => stockSymbol = value; }
        public string StockName { get => stockName; set => stockName = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public double StockValue { get => stockValue; set => stockValue = value; }
    }   
}
