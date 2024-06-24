﻿// <auto-generated />
using System;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                            Balance = 10000m,
                            Email = "gabriel123@gmail.com",
                            FirstName = "Gabriel",
                            LastName = "Silva"
                        });
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Investment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("Investments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                            ClientId = new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                            ProductId = new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                            Quantity = 5
                        });
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
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                            AvailableQuantity = 10,
                            Code = "PDT1",
                            CreatedAt = new DateTime(2024, 6, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9496),
                            Description = "Product 1 description",
                            ExpirationDate = new DateTime(2024, 7, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9484),
                            Name = "Product 1",
                            Price = 100m
                        },
                        new
                        {
                            Id = new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                            AvailableQuantity = 15,
                            Code = "PDT2",
                            CreatedAt = new DateTime(2024, 6, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9500),
                            Description = "Product 2 description",
                            ExpirationDate = new DateTime(2024, 6, 24, 15, 48, 38, 559, DateTimeKind.Local).AddTicks(9499),
                            Name = "Product 2",
                            Price = 200m
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
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                            ClientId = new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                            CreatedAt = new DateTime(2024, 6, 24, 13, 48, 38, 559, DateTimeKind.Local).AddTicks(9518),
                            ProductId = new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                            Quantity = 10,
                            TotalPrice = 0m,
                            TransactionType = 0,
                            UnitPrice = 0m
                        },
                        new
                        {
                            Id = new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                            ClientId = new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                            CreatedAt = new DateTime(2024, 6, 24, 14, 18, 38, 559, DateTimeKind.Local).AddTicks(9521),
                            ProductId = new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                            Quantity = 5,
                            TotalPrice = 0m,
                            TransactionType = 1,
                            UnitPrice = 0m
                        });
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Investment", b =>
                {
                    b.HasOne("InvestmentPortfolioManager.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestmentPortfolioManager.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InvestmentPortfolioManager.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("InvestmentPortfolioManager.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvestmentPortfolioManager.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
