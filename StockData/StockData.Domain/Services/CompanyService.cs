using AutoMapper;
using StockData.Domain.BusinessObjects;
using StockData.Domain.UnitOfWorks;
using CompanyEntity = StockData.Domain.Entities.Company;

namespace StockData.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IStockDataUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public CompanyService(IStockDataUnitOfWork stockDataUnitOfWork, IMapper mapper)
        {
            _unitofwork = stockDataUnitOfWork;
            _mapper = mapper;
        }

        public void CreateCompany(Company company)
        {
            var count = _unitofwork.Companies.GetCount(
                x => x.TradeCode == company.TradeCode);

            if(count == 0)
            {
                var entity = _mapper.Map<CompanyEntity>(company);
                _unitofwork.Companies.Add(entity);
                _unitofwork.Save();
            }
        }

        public int GetCompanyId(string tradeCode)
        {
            int id = 0;
            var getCompany = _unitofwork.Companies.GetByName(
                x => x.TradeCode == tradeCode);

            if(getCompany != null)
                id = getCompany.Id;

            return id;
        }
    }
}
