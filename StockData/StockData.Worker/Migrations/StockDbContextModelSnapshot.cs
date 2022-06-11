﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockData.Domain.DbContexts;

#nullable disable

namespace StockData.Worker.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockData.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TradeCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockData.Domain.Entities.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Change")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ClosePrice")
                        .HasColumnType("float");

                    b.Property<int>("CompnayId")
                        .HasColumnType("int");

                    b.Property<double?>("High")
                        .HasColumnType("float");

                    b.Property<double?>("LastTradingPrice")
                        .HasColumnType("float");

                    b.Property<double?>("Low")
                        .HasColumnType("float");

                    b.Property<double?>("Trade")
                        .HasColumnType("float");

                    b.Property<double?>("Value")
                        .HasColumnType("float");

                    b.Property<double?>("Volumn")
                        .HasColumnType("float");

                    b.Property<double?>("YesterdayClosePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CompnayId");

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("StockData.Domain.Entities.StockPrice", b =>
                {
                    b.HasOne("StockData.Domain.Entities.Company", "Company")
                        .WithMany("StockPrices")
                        .HasForeignKey("CompnayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("StockData.Domain.Entities.Company", b =>
                {
                    b.Navigation("StockPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
