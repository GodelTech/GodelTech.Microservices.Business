﻿using System;
using System.Collections.Generic;
using System.Linq;
using GodelTech.Microservices.Business.Demo;
using GodelTech.Microservices.Business.Demo.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace GodelTech.Microservices.Business.IntegrationTests
{
    public class AppTestFixture : WebApplicationFactory<Startup>
    {
        private bool _disposed;

        private readonly Guid _guid;
        private readonly SqliteConnection _sqliteConnection;

        public AppTestFixture()
        {
            _guid = Guid.NewGuid();

            _sqliteConnection = new SqliteConnection($"Data Source=InMemory{_guid};Mode=Memory;Cache=Shared");
            _sqliteConnection.CreateFunction("newsequentialid", Guid.NewGuid);
            _sqliteConnection.Open();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<CurrencyExchangeRateDbContext>();

            ConfigureDbContextOptionsBuilder(dbContextOptionsBuilder);

            DbContext = new CurrencyExchangeRateDbContext(dbContextOptionsBuilder.Options);

            DbContext.Database.EnsureCreated();
        }

        public ITestOutputHelper Output { get; set; }
        public CurrencyExchangeRateDbContext DbContext { get; }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                DbContext.Dispose();

                _sqliteConnection.Close();
                _sqliteConnection.Dispose();

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = base.CreateHostBuilder();

            builder.ConfigureLogging(
                logging =>
                {
                    logging.ClearProviders(); // Remove other loggers
                    logging.AddXUnit(Output); // Use the ITestOutputHelper instance
                }
            );

            return builder;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder
                .UseSetting("https_port", "8080")
                .ConfigureAppConfiguration(
                    configurationBuilder =>
                    {
                        configurationBuilder
                            .AddInMemoryCollection(
                                new KeyValuePair<string, string>[]
                                {
                                    new KeyValuePair<string, string>(
                                        "ConnectionStrings:DefaultConnection",
                                        $"Data Source=InMemory{_guid};Mode=Memory;Cache=Shared"
                                    ),
                                    new KeyValuePair<string, string>(
                                        "DataInitializerOptions:EnableDatabaseMigration",
                                        false.ToString()
                                    )
                                }
                            );
                    }
                )
                .ConfigureServices(
                    services =>
                    {
                        var factoryDescriptor = services.Single(x => x.ServiceType == typeof(IDbContextFactory<CurrencyExchangeRateDbContext>));
#pragma warning disable EF1001 // Internal EF Core API usage.
                        var factorySourceDescriptor = services.Single(x => x.ServiceType == typeof(IDbContextFactorySource<CurrencyExchangeRateDbContext>));
#pragma warning restore EF1001 // Internal EF Core API usage.
                        var genericOptionsDescriptor = services.Single(x => x.ServiceType == typeof(DbContextOptions));
                        var optionsDescriptor = services.Single(x => x.ServiceType == typeof(DbContextOptions<CurrencyExchangeRateDbContext>));

                        // remove IDbContextFactory to allow override
                        services.Remove(factoryDescriptor);
                        services.Remove(factorySourceDescriptor);
                        services.Remove(genericOptionsDescriptor);
                        services.Remove(optionsDescriptor);

                        services.AddDbContextFactory<CurrencyExchangeRateDbContext>(
                            ConfigureDbContextOptionsBuilder
                        );
                    }
                );
        }

        private void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlite(_sqliteConnection)
                .EnableSensitiveDataLogging();
        }
    }
}
