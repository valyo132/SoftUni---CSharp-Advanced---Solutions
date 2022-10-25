using System;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get { return PricePerShare * TotalNumberOfShares; } }

        public override string ToString()
            => $"Company: {this.CompanyName}" + Environment.NewLine +
               $"Director: {this.Director}" + Environment.NewLine +
               $"Price per share: ${this.PricePerShare}" + Environment.NewLine +
               $"Market capitalization: ${this.MarketCapitalization}";
    }
}
