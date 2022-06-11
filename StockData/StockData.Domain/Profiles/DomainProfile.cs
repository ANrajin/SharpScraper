using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEntity = StockData.Domain.Entities.Company;
using SPEntity = StockData.Domain.Entities.StockPrice;
using StockData.Domain.BusinessObjects;

namespace StockData.Domain.Profiles
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<CompanyEntity, Company>().ReverseMap();
            CreateMap<SPEntity, StockPrice>().ReverseMap();
        }
    }
}
