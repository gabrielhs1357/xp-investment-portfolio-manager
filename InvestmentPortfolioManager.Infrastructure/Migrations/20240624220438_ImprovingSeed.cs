using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImprovingSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("b567f04c-68f4-49cd-929e-c5933c5227b8"), "gabrielhs1357@gmail.com", "Gabriel", "Silva" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                columns: new[] { "Balance", "Email", "FirstName" },
                values: new object[] { 1000m, "henrique123@gmail.com", "Henrique" });

            migrationBuilder.UpdateData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                columns: new[] { "ProductId", "Quantity" },
                values: new object[] { new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                columns: new[] { "CreatedAt", "Description", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 24, 19, 4, 38, 553, DateTimeKind.Local).AddTicks(3097), "Not expiring!", new DateTime(2024, 8, 23, 19, 4, 38, 553, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                columns: new[] { "AvailableQuantity", "CreatedAt", "Description", "ExpirationDate", "Price" },
                values: new object[] { 10, new DateTime(2024, 6, 24, 19, 4, 38, 553, DateTimeKind.Local).AddTicks(3101), "Expiring soon!", new DateTime(2024, 6, 25, 10, 4, 38, 553, DateTimeKind.Local).AddTicks(3100), 100m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                columns: new[] { "CreatedAt", "TotalPrice", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 4, 38, 553, DateTimeKind.Local).AddTicks(3117), 1000m, 100m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                columns: new[] { "CreatedAt", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 34, 38, 553, DateTimeKind.Local).AddTicks(3121), 10, 1000m, 100m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("b567f04c-68f4-49cd-929e-c5933c5227b8"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                columns: new[] { "Balance", "Email", "FirstName" },
                values: new object[] { 10000m, "gabriel123@gmail.com", "Gabriel" });

            migrationBuilder.UpdateData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                columns: new[] { "ProductId", "Quantity" },
                values: new object[] { new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"), 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                columns: new[] { "CreatedAt", "Description", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9496), "Product 1 description", new DateTime(2024, 7, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                columns: new[] { "AvailableQuantity", "CreatedAt", "Description", "ExpirationDate", "Price" },
                values: new object[] { 15, new DateTime(2024, 6, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9500), "Product 2 description", new DateTime(2024, 6, 24, 15, 48, 38, 559, DateTimeKind.Local).AddTicks(9499), 200m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                columns: new[] { "CreatedAt", "TotalPrice", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 24, 13, 48, 38, 559, DateTimeKind.Local).AddTicks(9518), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                columns: new[] { "CreatedAt", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 24, 14, 18, 38, 559, DateTimeKind.Local).AddTicks(9521), 5, 0m, 0m });
        }
    }
}
