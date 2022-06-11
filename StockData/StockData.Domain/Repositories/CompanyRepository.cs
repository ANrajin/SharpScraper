using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Domain.DbContexts;
using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(StockDbContext context):base((DbContext)context)
        {
        }
    }
}
