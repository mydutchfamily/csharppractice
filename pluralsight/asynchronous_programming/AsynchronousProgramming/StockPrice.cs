using System;

namespace AsynchronousProgramming
{
    public class StockPrice
    {
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public string Ticker { get; set; }
        public DateTime TradeDate { get; set; }
        public int Volume { get; set; }
    }
}