using System;
using GodelTech.Business;
using GodelTech.Microservices.Business.Demo.Business.Contracts;
using GodelTech.Microservices.Business.Demo.Business.Models;
using GodelTech.Microservices.Business.Demo.Data.Contracts;
using GodelTech.Microservices.Business.Demo.Data.Entities;
using Microsoft.Extensions.Logging;

namespace GodelTech.Microservices.Business.Demo.Business
{
    public class BankService : BusinessService<BankEntity, Guid, ICurrencyExchangeRateUnitOfWork, BankDto, IBankAddDto, IBankEditDto>, IBankService
    {
        public BankService(
            ICurrencyExchangeRateUnitOfWork unitOfWork,
            IBusinessMapper businessMapper,
            ILogger<BankService> logger)
            : base(
                unitOfWork,
                x => x.BankRepository,
                businessMapper,
                logger)
        {

        }
    }
}
