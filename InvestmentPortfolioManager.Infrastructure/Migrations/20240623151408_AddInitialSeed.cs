using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Balance", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("1ad21366-4c91-4b2d-bbfa-96aedef5f6a8"), 20000m, "henrique123@gmail.com", "Henrique", "Silveira" },
                    { new Guid("c35383da-49dd-4b9e-be13-e9ce0577d468"), 10000m, "gabriel123@gmail.com", "Gabriel", "Silva" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Code", "CreatedAt", "Description", "ExpirationDate", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5246f94a-3973-4583-9649-eb5116da18fb"), 30, "PDT3", new DateTime(2024, 6, 23, 12, 14, 7, 794, DateTimeKind.Local).AddTicks(492), "Product 3 description", new DateTime(2024, 6, 23, 13, 14, 7, 794, DateTimeKind.Local).AddTicks(491), "Product 3", 300m, null },
                    { new Guid("75f0b781-0172-4a32-bce2-b29dd45e9ff1"), 20, "PDT2", new DateTime(2024, 6, 23, 12, 14, 7, 794, DateTimeKind.Local).AddTicks(489), "Product 2 description", new DateTime(2024, 7, 8, 12, 14, 7, 794, DateTimeKind.Local).AddTicks(488), "Product 2", 200m, null },
                    { new Guid("d1552567-b975-45fb-ba7b-da3bf240b4aa"), 10, "PDT1", new DateTime(2024, 6, 23, 12, 14, 7, 794, DateTimeKind.Local).AddTicks(475), "Product 1 description", new DateTime(2024, 7, 23, 12, 14, 7, 794, DateTimeKind.Local).AddTicks(462), "Product 1", 100m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("1ad21366-4c91-4b2d-bbfa-96aedef5f6a8"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("c35383da-49dd-4b9e-be13-e9ce0577d468"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5246f94a-3973-4583-9649-eb5116da18fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75f0b781-0172-4a32-bce2-b29dd45e9ff1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1552567-b975-45fb-ba7b-da3bf240b4aa"));
        }
    }
}
