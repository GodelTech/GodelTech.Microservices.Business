﻿using System;
using System.Collections.Generic;
using GodelTech.Business;
using GodelTech.Business.AutoMapper;
using GodelTech.Microservices.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]
namespace GodelTech.Microservices.Business
{
    /// <summary>
    /// Business initializer.
    /// </summary>
    public class BusinessInitializer<TStartup> : IMicroserviceInitializer
        where TStartup : class
    {
        private readonly List<Action<IServiceCollection>> _configureServicesList = new List<Action<IServiceCollection>>();

        /// <inheritdoc />
        public virtual void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper
            // Stryker disable once statement
            // ignored as in Data we also add this AutoMapper
            services.AddAutoMapper(typeof(TStartup).Assembly);

            // GodelTech.Business.AutoMapper
            services.AddScoped<IBusinessMapper, BusinessMapper>();

            // Services
            foreach (var action in _configureServicesList)
            {
                action.Invoke(services);
            }
        }

        /// <inheritdoc />
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        /// <inheritdoc />
        public virtual void ConfigureEndpoints(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        /// <summary>
        /// Adds registration of Service
        /// </summary>
        /// <typeparam name="TIService">Interface of service.</typeparam>
        /// <typeparam name="TService">Implementation of service.</typeparam>
        /// <typeparam name="TDto">The type of the T data transfer object.</typeparam>
        /// <typeparam name="TAddDto">The type of the T type.</typeparam>
        /// <typeparam name="TEditDto">The type of the T type.</typeparam>
        /// <typeparam name="TKey">The type of the T key.</typeparam>
        /// <returns>BusinessInitializer.</returns>
#pragma warning disable S2436 // Reduce the number of generic parameters in the 'BusinessInitializer.WithService' method to no more than the 3 authorized.
        public BusinessInitializer<TStartup> WithService<TIService, TService, TDto, TAddDto, TEditDto, TKey>()
#pragma warning restore S2436 // Reduce the number of generic parameters in the 'BusinessInitializer.WithService' method to no more than the 3 authorized.
            where TIService : class, IBusinessService<TDto, TAddDto, TEditDto, TKey>
            where TService : class, TIService
            where TDto : class, IDto<TKey>
            where TAddDto : class
            where TEditDto : class, IDto<TKey>
        {
            return WithService<TIService, TService>();
        }

        /// <summary>
        /// Adds registration of Service
        /// </summary>
        /// <typeparam name="TIService">Interface of service.</typeparam>
        /// <typeparam name="TService">Implementation of service.</typeparam>
        /// <returns>BusinessInitializer.</returns>
        public BusinessInitializer<TStartup> WithService<TIService, TService>()
            where TIService : class
            where TService : class, TIService
        {
            _configureServicesList.Add(
                services => services
                    .AddTransient<TIService, TService>()
            );

            return this;
        }
    }
}
