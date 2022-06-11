using StockData.Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.Services
{
    public interface ICompanyService
    {
        void CreateCompany(Company company);
        int GetCompanyId(string tradeCode);
    }
}
