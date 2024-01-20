﻿using System;
using GodelTech.Data.EntityFrameworkCore;
using GodelTech.Microservices.Business.Demo.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.Microservices.Business.Demo.Data
{
    public class CurrencyExchangeRateDbContext : DbContextBase
    {
        public CurrencyExchangeRateDbContext(DbContextOptions<CurrencyExchangeRateDbContext> dbContextOptions)
            : base(dbContextOptions, "currencyExchangeRate")
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BankConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration(SchemaName));
        }
    }
}
