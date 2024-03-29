﻿using System;
using GodelTech.Data.EntityFrameworkCore;
using GodelTech.Microservices.Business.Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GodelTech.Microservices.Business.Demo.Data.Configurations
{
    public class BankConfiguration : EntityTypeConfiguration<BankEntity, Guid>
    {
        public BankConfiguration(string schemaName)
            : base(schemaName)
        {

        }

        public override void Configure(EntityTypeBuilder<BankEntity> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            // Table
            builder.ToTable("Bank", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(x => x.Name).HasColumnType("nvarchar(255)").IsRequired();
        }
    }
}
