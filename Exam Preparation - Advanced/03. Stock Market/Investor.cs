using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count { get { return Portfolio.Count; } }

        public List<Stock> Portfolio { get; set; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(x => x.CompanyName == companyName))
                return $"{companyName} does not exist.";

            var company = Portfolio.First(x => x.CompanyName == companyName);
            if (sellPrice < company.PricePerShare)
                return $"Cannot sell {companyName}.";

            Portfolio.Remove(company);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.Find(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
            => $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:" +
               Environment.NewLine +
               string.Join(Environment.NewLine, this.Portfolio);
    }
}
