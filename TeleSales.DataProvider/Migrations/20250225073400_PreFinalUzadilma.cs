using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class PreFinalUzadilma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.Uzadilmas_Main.Сhannels_ChannelId",
                table: "Main.Uzadilmas");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 25, 11, 33, 56, 934, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.AddForeignKey(
                name: "FK_Main.Uzadilmas_Main.Сhannels_ChannelId",
                table: "Main.Uzadilmas",
                column: "ChannelId",
                principalTable: "Main.Сhannels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.Uzadilmas_Main.Сhannels_ChannelId",
                table: "Main.Uzadilmas");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 24, 13, 48, 58, 332, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.AddForeignKey(
                name: "FK_Main.Uzadilmas_Main.Сhannels_ChannelId",
                table: "Main.Uzadilmas",
                column: "ChannelId",
                principalTable: "Main.Сhannels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
