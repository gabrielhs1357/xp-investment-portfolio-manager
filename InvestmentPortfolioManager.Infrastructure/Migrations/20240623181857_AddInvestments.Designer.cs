﻿// <auto-generated />
using System;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240623181857_AddInvestments")]
    partial class AddInvestments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("40f7725d-9a07-480f-b963-c9a67bebccdc"),
                            Balance = 10000m,
                            Email = "gabriel123@gmail.com",
                            FirstName = "Gabriel",
                            LastName = "Silva"
                        },
                        new
                        {
                            Id = new Guid("8a27a77c-2e13-4b28-8971-9ff3667e81d0"),
                            Balance = 20000m,
                            Email = "henrique123@gmail.com",
                            FirstName = "Henrique",
                            LastName = "Silveira"
                        },
                        new
                        {
                            Id = new Guid("656a9128-f9ff-4b00-97fa-03007ff0d043"),
                            Balance = 30000m,
                            Email = "thiago123@gmail.com",
                            FirstName = "Thiago",
                            LastName = "Silva"
                        });
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Investment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AveragePurchasePrice")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a9799b17-c639-417c-a991-c64149c680fe"),
                            AvailableQuantity = 10,
                            Code = "PDT1",
                            CreatedAt = new DateTime(2024, 6, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6452),
                            Description = "Product 1 description",
                            ExpirationDate = new DateTime(2024, 7, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6439),
                            Name = "Product 1",
                            Price = 100m
                        },
                        new
                        {
                            Id = new Guid("e60d88e5-b6b1-4b13-b9b7-a47780086330"),
                            AvailableQuantity = 20,
                            Code = "PDT2",
                            CreatedAt = new DateTime(2024, 6, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6456),
                            Description = "Product 2 description",
                            ExpirationDate = new DateTime(2024, 7, 8, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6455),
                            Name = "Product 2",
                            Price = 200m
                        },
                        new
                        {
                            Id = new Guid("fa1864be-4e69-4f8d-aef2-65a8638f963f"),
                            AvailableQuantity = 30,
                            Code = "PDT3",
                            CreatedAt = new DateTime(2024, 6, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6460),
                            Description = "Product 3 description",
                            ExpirationDate = new DateTime(2024, 6, 23, 16, 18, 57, 394, DateTimeKind.Local).AddTicks(6459),
                            Name = "Product 3",
                            Price = 300m
                        });
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
