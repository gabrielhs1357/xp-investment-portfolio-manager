using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortfolioManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 23, 15, 34, 30, 880, DateTimeKind.Local).AddTicks(4637), new DateTime(2024, 7, 23, 15, 34, 30, 880, DateTimeKind.Local).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                columns: new[] { "CreatedAt", "ExpirationDate" },
                values: new object[] { new DateTime(2024, 6, 23, 15, 34, 30, 880, DateTimeKind.Local).AddTicks(4642), new DateTime(2024, 6, 23, 16, 34, 30, 880, DateTimeKind.Local).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 14, 34, 30, 880, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("309ffbc9-2506-427c-bd99-dac517693a24"),
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 15, 4, 30, 880, DateTimeKind.Local).AddTicks(4664));
        }
    }
}
