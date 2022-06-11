using AutoMapper;
using StockData.Domain.BusinessObjects;
using StockData.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockPriceEnitity = StockData.Domain.Entities.StockPrice;

namespace StockData.Domain.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockDataUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public StockPriceService(IStockDataUnitOfWork stockDataUnitOfWork, IMapper mapper)
        {
            _unitofwork = stockDataUnitOfWork;
            _mapper = mapper;
        }

        public void CreateStockPrice(StockPrice stockPrice)
        {
            var entity = _mapper.Map<StockPriceEnitity>(stockPrice);
            _unitofwork.StockPrices.Add(entity);
            _unitofwork.Save();
        }
    }
}
