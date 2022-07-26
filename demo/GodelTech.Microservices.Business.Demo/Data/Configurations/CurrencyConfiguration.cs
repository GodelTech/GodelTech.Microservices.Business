﻿using System;
using GodelTech.Data.EntityFrameworkCore;
using GodelTech.Microservices.Business.Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GodelTech.Microservices.Business.Demo.Data.Configurations
{
    public class CurrencyConfiguration : EntityTypeConfiguration<CurrencyEntity, int>
    {
        public CurrencyConfiguration(string schemaName)
            : base(schemaName)
        {

        }

        public override void Configure(EntityTypeBuilder<CurrencyEntity> builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            // Table
            builder.ToTable("Currency", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.AlphabeticCode).HasColumnType("nvarchar(3)").IsRequired();
        }
    }
}