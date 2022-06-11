using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Domain.DbContexts;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.UnitOfWorks
{
    public class StockDataUnitOfWork : UnitOfWork, IStockDataUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }

        public StockDataUnitOfWork(StockDbContext DbContext,
            ICompanyRepository companyRepository,
            IStockPriceRepository stockPriceRepository)
            :base((DbContext)DbContext)
        {
            Companies = companyRepository;
            StockPrices = stockPriceRepository;
        }
    }
}
