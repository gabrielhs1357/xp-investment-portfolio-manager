using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnotationsAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePurchasePrice",
                table: "Investments");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Transactions",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Transactions",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9496), new DateTime(2024, 7, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 24, 14, 48, 38, 559, DateTimeKind.Local).AddTicks(9500), new DateTime(2024, 6, 24, 15, 48, 38, 559, DateTimeKind.Local).AddTicks(9499) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 24, 13, 48, 38, 559, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 24, 14, 18, 38, 559, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_ClientId",
                table: "Investments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_ProductId",
                table: "Investments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Clients_ClientId",
                table: "Investments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Products_ProductId",
                table: "Investments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_ProductId",
                table: "Transactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Clients_ClientId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Products_ProductId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_ProductId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Investments_ClientId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_ProductId",
                table: "Investments");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<decimal>(
                name: "AveragePurchasePrice",
                table: "Investments",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Investments",
                keyColumn: "Id",
                keyValue: new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                column: "AveragePurchasePrice",
                value: 200m);

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
    }
}
