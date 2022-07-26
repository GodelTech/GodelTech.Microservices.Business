﻿// <auto-generated />
using System;
using GodelTech.Microservices.Business.Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GodelTech.Microservices.Business.Demo.Migrations
{
    [DbContext(typeof(CurrencyExchangeRateDbContext))]
    [Migration("20220726094542_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GodelTech.Microservices.Business.Demo.Data.Entities.BankEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Bank", "currencyExchangeRate");
                });

            modelBuilder.Entity("GodelTech.Microservices.Business.Demo.Data.Entities.CurrencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AlphabeticCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Currency", "currencyExchangeRate");
                });
#pragma warning restore 612, 618
        }
    }
}