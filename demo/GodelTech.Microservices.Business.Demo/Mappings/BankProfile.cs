using AutoMapper;
using GodelTech.Microservices.Business.Demo.Business.Models;
using GodelTech.Microservices.Business.Demo.Models.Bank;

namespace GodelTech.Microservices.Business.Demo.Mappings
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BankDto, BankModel>();
        }
    }
}
