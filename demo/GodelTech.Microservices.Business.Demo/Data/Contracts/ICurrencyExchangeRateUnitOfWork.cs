using System;
using GodelTech.Data;
using GodelTech.Microservices.Business.Demo.Data.Entities;

namespace GodelTech.Microservices.Business.Demo.Data.Contracts
{
    public interface ICurrencyExchangeRateUnitOfWork : IUnitOfWork
    {
        IRepository<BankEntity, Guid> BankRepository { get; }

        ICurrencyRepository CurrencyRepository { get; }
    }
}
