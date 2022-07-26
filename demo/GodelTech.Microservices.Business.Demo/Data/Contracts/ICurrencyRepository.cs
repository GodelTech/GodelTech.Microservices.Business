using System;
using GodelTech.Data;
using GodelTech.Microservices.Business.Demo.Data.Entities;

namespace GodelTech.Microservices.Business.Demo.Data.Contracts
{
    public interface ICurrencyRepository : IRepository<CurrencyEntity, int>
    {
        [Obsolete("Insert operation is not allowed.", true)]
        new CurrencyEntity Insert(CurrencyEntity entity);
    }
}
