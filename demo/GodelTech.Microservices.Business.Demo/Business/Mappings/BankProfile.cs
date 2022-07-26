using AutoMapper;
using GodelTech.Microservices.Business.Demo.Business.Contracts;
using GodelTech.Microservices.Business.Demo.Business.Models;
using GodelTech.Microservices.Business.Demo.Data.Entities;

namespace GodelTech.Microservices.Business.Demo.Business.Mappings
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BankEntity, BankDto>();

            CreateMap<IBankAddDto, BankEntity>();

            CreateMap<IBankEditDto, BankEntity>();
        }
    }
}
