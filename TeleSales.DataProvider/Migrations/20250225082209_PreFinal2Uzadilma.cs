using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class PreFinal2Uzadilma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 25, 12, 22, 6, 693, DateTimeKind.Local).AddTicks(3274));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 25, 11, 33, 56, 934, DateTimeKind.Local).AddTicks(3883));
        }
    }
}
