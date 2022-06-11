using Autofac;
using HtmlAgilityPack;
using StockData.Domain.BusinessObjects;
using StockData.Domain.Services;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICompanyService _companyService;
        private readonly IStockPriceService _stockPriceService;

        public Worker(ILogger<Worker> logger,
            ILifetimeScope scope,
            ICompanyService companyService,
            IStockPriceService stockPriceService)
        {
            _logger = logger;
            _companyService = companyService;
            _stockPriceService = stockPriceService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");
                var status = document.DocumentNode
                    .SelectNodes("//span[@class='time']//span[@class='green']//b")
                    .FirstOrDefault();

                if (status.InnerText.ToString().ToLower().Trim() == "open")
                {
                    InsertStockPrice(document);

                    Console.WriteLine("Data Inserted Successfully!");
                    _logger.LogInformation("Data Inserted Successfully!");
                }
                await Task.Delay(60000, stoppingToken);
            }
        }

        private void InsertStockPrice(HtmlDocument document)
        {
            var tablenodes = document.DocumentNode
                .SelectNodes("//table[@class='table table-bordered background-white shares-table fixedHeader']//tr");

            for (var i = 1; i < tablenodes.Count(); i++)
            {
                var column = tablenodes[i].ChildNodes.Where(
                    x => x.EndNode.Name != "#text").ToArray();

                var company = new Company
                {
                    TradeCode = Convert.ToString(column[1].InnerText.ToString())
                };

                _companyService.CreateCompany(company);

                var ltp = column[2].InnerText.ToString().Replace(",", String.Empty);
                var high = column[3].InnerText.ToString().Replace(",", String.Empty);
                var low = column[4].InnerText.ToString().Replace(",", String.Empty);
                var cp = column[5].InnerText.ToString().Replace(",", String.Empty);
                var ycp = column[6].InnerText.ToString().Replace(",", String.Empty);
                var change = column[7].InnerText.ToString().Replace(",", String.Empty);
                var trade = column[8].InnerText.ToString().Replace(",", String.Empty);
                var value = column[9].InnerText.ToString().Replace(",", String.Empty);
                var volumn = column[10].InnerText.ToString().Replace(",", String.Empty);

                var stockPrice = new StockPrice
                {
                    CompnayId = Convert.ToInt32(column[0].InnerText.ToString()),
                    LastTradingPrice = Convert.ToDouble(ltp),
                    High = Convert.ToDouble(high),
                    Low = Convert.ToDouble(low),
                    ClosePrice = Convert.ToDouble(cp),
                    YesterdayClosePrice = Convert.ToDouble(ycp),
                    Change = change,
                    Trade = Convert.ToDouble(trade),
                    Value = Convert.ToDouble(value),
                    Volumn = Convert.ToDouble(volumn),
                };

                _stockPriceService.CreateStockPrice(stockPrice);
            }
        }
    }
}