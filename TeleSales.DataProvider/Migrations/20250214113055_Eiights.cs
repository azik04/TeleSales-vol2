using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Eiights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Main.Сhannels_СhannelId",
                table: "Main.CallCenters");

            migrationBuilder.RenameColumn(
                name: "СhannelId",
                table: "Main.CallCenters",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_СhannelId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_ChannelId");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 14, 15, 30, 52, 621, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Main.Сhannels_ChannelId",
                table: "Main.CallCenters",
                column: "ChannelId",
                principalTable: "Main.Сhannels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Main.Сhannels_ChannelId",
                table: "Main.CallCenters");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Main.CallCenters",
                newName: "СhannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_ChannelId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_СhannelId");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 14, 14, 57, 17, 834, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Main.Сhannels_СhannelId",
                table: "Main.CallCenters",
                column: "СhannelId",
                principalTable: "Main.Сhannels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
