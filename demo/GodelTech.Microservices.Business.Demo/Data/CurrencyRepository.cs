using GodelTech.Data;
using GodelTech.Data.EntityFrameworkCore;
using GodelTech.Microservices.Business.Demo.Data.Contracts;
using GodelTech.Microservices.Business.Demo.Data.Entities;

namespace GodelTech.Microservices.Business.Demo.Data
{
    public class CurrencyRepository : Repository<CurrencyEntity, int>, ICurrencyRepository
    {
        public CurrencyRepository(CurrencyExchangeRateDbContext dbContext, IDataMapper dataMapper)
            : base(dbContext, dataMapper)
        {

        }
    }
}
