using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SimplifySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("40f7725d-9a07-480f-b963-c9a67bebccdc"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("656a9128-f9ff-4b00-97fa-03007ff0d043"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("8a27a77c-2e13-4b28-8971-9ff3667e81d0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a9799b17-c639-417c-a991-c64149c680fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e60d88e5-b6b1-4b13-b9b7-a47780086330"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa1864be-4e69-4f8d-aef2-65a8638f963f"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Balance", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"), 10000m, "gabriel123@gmail.com", "Gabriel", "Silva" });

            migrationBuilder.InsertData(
                table: "Investments",
                columns: new[] { "Id", "AveragePurchasePrice", "ClientId", "ProductId", "Quantity" },
                values: new object[] { new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"), 200m, new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"), new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"), 5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Code", "CreatedAt", "Description", "ExpirationDate", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"), 10, "PDT1", new DateTime(2024, 6, 23, 15, 34, 30, 880, DateTimeKind.Local).AddTicks(4637), "Product 1 description", new DateTime(2024, 7, 23, 15, 34, 30, 880, DateTimeKind.Local).AddTicks(4615), "Product 1", 100m, null },
                    { new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"), 15, "PDT2", new DateTime(2024, 6, 23, 15, 34, 30, 880, DateTimeKind.Local).AddTicks(4642), "Product 2 description", new DateTime(2024, 6, 23, 16, 34, 30, 880, DateTimeKind.Local).AddTicks(4641), "Product 2", 200m, null }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ClientId", "CreatedAt", "ProductId", "Quantity", "TotalPrice", "TransactionType", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"), new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"), new DateTime(2024, 6, 23, 14, 34, 30, 880, DateTimeKind.Local).AddTicks(4660), new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"), 10, 0m, 0, 0m },
                    { new Guid("309ffbc9-2506-427c-bd99-dac517693a24"), new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"), new DateTime(2024, 6, 23, 15, 4, 30, 880, DateTimeKind.Local).AddTicks(4664), new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"), 5, 0m, 1, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"));

            migrationBuilder.DeleteData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Balance", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("40f7725d-9a07-480f-b963-c9a67bebccdc"), 10000m, "gabriel123@gmail.com", "Gabriel", "Silva" },
                    { new Guid("656a9128-f9ff-4b00-97fa-03007ff0d043"), 30000m, "thiago123@gmail.com", "Thiago", "Silva" },
                    { new Guid("8a27a77c-2e13-4b28-8971-9ff3667e81d0"), 20000m, "henrique123@gmail.com", "Henrique", "Silveira" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Code", "CreatedAt", "Description", "ExpirationDate", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a9799b17-c639-417c-a991-c64149c680fe"), 10, "PDT1", new DateTime(2024, 6, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6452), "Product 1 description", new DateTime(2024, 7, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6439), "Product 1", 100m, null },
                    { new Guid("e60d88e5-b6b1-4b13-b9b7-a47780086330"), 20, "PDT2", new DateTime(2024, 6, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6456), "Product 2 description", new DateTime(2024, 7, 8, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6455), "Product 2", 200m, null },
                    { new Guid("fa1864be-4e69-4f8d-aef2-65a8638f963f"), 30, "PDT3", new DateTime(2024, 6, 23, 15, 18, 57, 394, DateTimeKind.Local).AddTicks(6460), "Product 3 description", new DateTime(2024, 6, 23, 16, 18, 57, 394, DateTimeKind.Local).AddTicks(6459), "Product 3", 300m, null }
                });
        }
    }
}
