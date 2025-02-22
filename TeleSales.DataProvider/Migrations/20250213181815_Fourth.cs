using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SubResultId",
                table: "Main.Debitors",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 22, 18, 12, 278, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.CreateIndex(
                name: "IX_Main.Debitors_SubResultId",
                table: "Main.Debitors",
                column: "SubResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Main.Debitors_List.Results_SubResultId",
                table: "Main.Debitors",
                column: "SubResultId",
                principalTable: "List.Results",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.Debitors_List.Results_SubResultId",
                table: "Main.Debitors");

            migrationBuilder.DropIndex(
                name: "IX_Main.Debitors_SubResultId",
                table: "Main.Debitors");

            migrationBuilder.DropColumn(
                name: "SubResultId",
                table: "Main.Debitors");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 10, 17, 22, 1, 768, DateTimeKind.Local).AddTicks(562));
        }
    }
}
