using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_List.ApplicationTypes_ApplicationTypeId",
                table: "Main.CallCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_List.Regions_RegionId",
                table: "Main.CallCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_Main.Users_ExcludedBy",
                table: "Main.CallCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_Main.Сhannels_СhannelId",
                table: "Main.CallCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_Rel.Administrations_AdministrationId",
                table: "Main.CallCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_Rel.Departments_DepartmentId",
                table: "Main.CallCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenter_Rel.Employers_EmployerId",
                table: "Main.CallCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Main.CallCenter",
                table: "Main.CallCenter");

            migrationBuilder.RenameTable(
                name: "Main.CallCenter",
                newName: "Main.CallCenters");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_RegionId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_ExcludedBy",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_ExcludedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_EmployerId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_DepartmentId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_ApplicationTypeId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_ApplicationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_AdministrationId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_AdministrationId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenter_СhannelId",
                table: "Main.CallCenters",
                newName: "IX_Main.CallCenters_СhannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Main.CallCenters",
                table: "Main.CallCenters",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 14, 12, 46, 0, 771, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_List.ApplicationTypes_ApplicationTypeId",
                table: "Main.CallCenters",
                column: "ApplicationTypeId",
                principalTable: "List.ApplicationTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_List.Regions_RegionId",
                table: "Main.CallCenters",
                column: "RegionId",
                principalTable: "List.Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Main.Users_ExcludedBy",
                table: "Main.CallCenters",
                column: "ExcludedBy",
                principalTable: "Main.Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Main.Сhannels_СhannelId",
                table: "Main.CallCenters",
                column: "СhannelId",
                principalTable: "Main.Сhannels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Rel.Administrations_AdministrationId",
                table: "Main.CallCenters",
                column: "AdministrationId",
                principalTable: "Rel.Administrations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Rel.Departments_DepartmentId",
                table: "Main.CallCenters",
                column: "DepartmentId",
                principalTable: "Rel.Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenters_Rel.Employers_EmployerId",
                table: "Main.CallCenters",
                column: "EmployerId",
                principalTable: "Rel.Employers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_List.ApplicationTypes_ApplicationTypeId",
                table: "Main.CallCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_List.Regions_RegionId",
                table: "Main.CallCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Main.Users_ExcludedBy",
                table: "Main.CallCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Main.Сhannels_СhannelId",
                table: "Main.CallCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Rel.Administrations_AdministrationId",
                table: "Main.CallCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Rel.Departments_DepartmentId",
                table: "Main.CallCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Main.CallCenters_Rel.Employers_EmployerId",
                table: "Main.CallCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Main.CallCenters",
                table: "Main.CallCenters");

            migrationBuilder.RenameTable(
                name: "Main.CallCenters",
                newName: "Main.CallCenter");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_RegionId",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_ExcludedBy",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_ExcludedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_EmployerId",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_DepartmentId",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_ApplicationTypeId",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_ApplicationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_AdministrationId",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_AdministrationId");

            migrationBuilder.RenameIndex(
                name: "IX_Main.CallCenters_СhannelId",
                table: "Main.CallCenter",
                newName: "IX_Main.CallCenter_СhannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Main.CallCenter",
                table: "Main.CallCenter",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Main.Users",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 22, 18, 12, 278, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_List.ApplicationTypes_ApplicationTypeId",
                table: "Main.CallCenter",
                column: "ApplicationTypeId",
                principalTable: "List.ApplicationTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_List.Regions_RegionId",
                table: "Main.CallCenter",
                column: "RegionId",
                principalTable: "List.Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_Main.Users_ExcludedBy",
                table: "Main.CallCenter",
                column: "ExcludedBy",
                principalTable: "Main.Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_Main.Сhannels_СhannelId",
                table: "Main.CallCenter",
                column: "СhannelId",
                principalTable: "Main.Сhannels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_Rel.Administrations_AdministrationId",
                table: "Main.CallCenter",
                column: "AdministrationId",
                principalTable: "Rel.Administrations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_Rel.Departments_DepartmentId",
                table: "Main.CallCenter",
                column: "DepartmentId",
                principalTable: "Rel.Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Main.CallCenter_Rel.Employers_EmployerId",
                table: "Main.CallCenter",
                column: "EmployerId",
                principalTable: "Rel.Employers",
                principalColumn: "id");
        }
    }
}
