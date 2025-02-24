using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Demo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DasiyiziNovu",
                table: "Main.Uzadilmas",
                newName: "DasiyiciNovu");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 24, 13, 48, 58, 332, DateTimeKind.Local).AddTicks(8571));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DasiyiciNovu",
                table: "Main.Uzadilmas",
                newName: "DasiyiziNovu");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 18, 15, 45, 7, 799, DateTimeKind.Local).AddTicks(1232));
        }
    }
}
