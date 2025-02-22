using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class MakeCitNotNoolp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_List.Regions_Cities_CityId",
                table: "List.Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "List.Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_List.Cities",
                table: "List.Cities",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 18, 15, 45, 7, 799, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.AddForeignKey(
                name: "FK_List.Regions_List.Cities_CityId",
                table: "List.Regions",
                column: "CityId",
                principalTable: "List.Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_List.Regions_List.Cities_CityId",
                table: "List.Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_List.Cities",
                table: "List.Cities");

            migrationBuilder.RenameTable(
                name: "List.Cities",
                newName: "Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 18, 14, 22, 36, 775, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.AddForeignKey(
                name: "FK_List.Regions_Cities_CityId",
                table: "List.Regions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
