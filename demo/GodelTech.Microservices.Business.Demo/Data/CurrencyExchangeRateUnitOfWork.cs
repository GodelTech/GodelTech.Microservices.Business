﻿using System;
using GodelTech.Data;
using GodelTech.Data.EntityFrameworkCore;
using GodelTech.Microservices.Business.Demo.Data.Contracts;
using GodelTech.Microservices.Business.Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.Microservices.Business.Demo.Data
{
    public class CurrencyExchangeRateUnitOfWork : UnitOfWork<CurrencyExchangeRateDbContext>, ICurrencyExchangeRateUnitOfWork
    {
        public CurrencyExchangeRateUnitOfWork(
            Func<CurrencyExchangeRateDbContext, IRepository<BankEntity, Guid>> bankRepository,
            Func<CurrencyExchangeRateDbContext, ICurrencyRepository> currencyRepository,
            IDbContextFactory<CurrencyExchangeRateDbContext> dbContextFactory)
            : base(dbContextFactory)
        {
            if (bankRepository == null) throw new ArgumentNullException(nameof(bankRepository));
            if (currencyRepository == null) throw new ArgumentNullException(nameof(currencyRepository));

            RegisterRepository(bankRepository(DbContext));
            RegisterRepository(currencyRepository(DbContext));
        }

        public IRepository<BankEntity, Guid> BankRepository => GetRepository<BankEntity, Guid>();

        public ICurrencyRepository CurrencyRepository => GetRepository<ICurrencyRepository, CurrencyEntity, int>();
    }
}
