using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Sixsth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForwardTo",
                table: "Main.CallCenters");

            migrationBuilder.AddColumn<long>(
                name: "ChannelId",
                table: "Main.CallCenters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 14, 13, 8, 21, 678, DateTimeKind.Local).AddTicks(1032));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Main.CallCenters");

            migrationBuilder.AddColumn<string>(
                name: "ForwardTo",
                table: "Main.CallCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 14, 12, 46, 0, 771, DateTimeKind.Local).AddTicks(5346));
        }
    }
}
