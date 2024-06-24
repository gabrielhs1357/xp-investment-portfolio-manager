using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClientAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Clients",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 24, 13, 49, 40, 71, DateTimeKind.Local).AddTicks(6799), new DateTime(2024, 7, 24, 13, 49, 40, 71, DateTimeKind.Local).AddTicks(6776) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 24, 13, 49, 40, 71, DateTimeKind.Local).AddTicks(6802), new DateTime(2024, 6, 24, 14, 49, 40, 71, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 24, 12, 49, 40, 71, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 24, 13, 19, 40, 71, DateTimeKind.Local).AddTicks(6823));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 23, 16, 36, 7, 973, DateTimeKind.Local).AddTicks(8092), new DateTime(2024, 7, 23, 16, 36, 7, 973, DateTimeKind.Local).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 23, 16, 36, 7, 973, DateTimeKind.Local).AddTicks(8098), new DateTime(2024, 6, 23, 17, 36, 7, 973, DateTimeKind.Local).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 15, 36, 7, 973, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 16, 6, 7, 973, DateTimeKind.Local).AddTicks(8158));
        }
    }
}
