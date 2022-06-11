using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.BusinessObjects
{
    public class Company
    {
        public int Id { get; set; }
        public string? TradeCode { get; set; }
        public List<StockPrice>? StockPrices { get; set; }
    }
}
