using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleSales.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List.ApplicationTypes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List.ApplicationTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "List.Regions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List.Regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "List.Results",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List.Results", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "List.Statuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List.Statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Main.Сhannels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main.Сhannels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Main.Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main.Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rel.Administrations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel.Administrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "List.SubResults",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultId = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List.SubResults", x => x.id);
                    table.ForeignKey(
                        name: "FK_List.SubResults_List.Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "List.Results",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Main.Debitors",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VOEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PermissionEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<long>(type: "bigint", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDone = table.Column<bool>(type: "bit", nullable: false),
                    isExcluding = table.Column<bool>(type: "bit", nullable: false),
                    ChannelId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    ResultId = table.Column<long>(type: "bigint", nullable: true),
                    ExcludedBy = table.Column<long>(type: "bigint", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastStatusUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextCall = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDebt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Year2018 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Year2019 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Year2020 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Year2021 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Year2022 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Year2023 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month1_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month2_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month3_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month4_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month5_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month6_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month7_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month8_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month9_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month10_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month11_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month12_2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month1_2025 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month2_2025 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Month3_2025 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main.Debitors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Main.Debitors_List.Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "List.Results",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.Debitors_List.Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "List.Statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.Debitors_Main.Users_ExcludedBy",
                        column: x => x.ExcludedBy,
                        principalTable: "Main.Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.Debitors_Main.Сhannels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Main.Сhannels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Main.UserChannels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    СhannelId = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main.UserChannels", x => x.id);
                    table.ForeignKey(
                        name: "FK_Main.UserChannels_Main.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Main.Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.UserChannels_Main.Сhannels_СhannelId",
                        column: x => x.СhannelId,
                        principalTable: "Main.Сhannels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rel.Departments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministrationId = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel.Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rel.Departments_Rel.Administrations_AdministrationId",
                        column: x => x.AdministrationId,
                        principalTable: "Rel.Administrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Main.Uzadilmas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuraciyetNomresi = table.Column<long>(type: "bigint", nullable: false),
                    PermissionStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PermissionEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Yayici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VOEN = table.Column<long>(type: "bigint", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DasiyiziNovu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IcazeMuddeti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TəyinatVöen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MüraciətSayı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaşıyıcıSayı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChannelId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main.Uzadilmas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Main.Uzadilmas_List.Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "List.Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.Uzadilmas_Main.Сhannels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Main.Сhannels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Main.Uzadilmas_Rel.Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Rel.Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rel.Employers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel.Employers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rel.Employers_Rel.Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Rel.Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Main.CallCenter",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VOEN = table.Column<long>(type: "bigint", nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isForwarding = table.Column<bool>(type: "bit", nullable: false),
                    ForwardTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcludedBy = table.Column<long>(type: "bigint", nullable: false),
                    СhannelId = table.Column<long>(type: "bigint", nullable: false),
                    AdministrationId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    EmployerId = table.Column<long>(type: "bigint", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true),
                    ApplicationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main.CallCenter", x => x.id);
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_List.ApplicationTypes_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "List.ApplicationTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_List.Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "List.Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_Main.Users_ExcludedBy",
                        column: x => x.ExcludedBy,
                        principalTable: "Main.Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_Main.Сhannels_СhannelId",
                        column: x => x.СhannelId,
                        principalTable: "Main.Сhannels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_Rel.Administrations_AdministrationId",
                        column: x => x.AdministrationId,
                        principalTable: "Rel.Administrations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_Rel.Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Rel.Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Main.CallCenter_Rel.Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Rel.Employers",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Main.Users",
                columns: new[] { "id", "CreateAt", "Email", "FullName", "Password", "Role", "isDeleted" },
                values: new object[] { 1L, new DateTime(2025, 2, 10, 12, 33, 22, 320, DateTimeKind.Local).AddTicks(471), "admin@adra.gov.az", "Admin", "Admin123", 2, false });

            migrationBuilder.CreateIndex(
                name: "IX_List.SubResults_ResultId",
                table: "List.SubResults",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_СhannelId",
                table: "Main.CallCenter",
                column: "СhannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_AdministrationId",
                table: "Main.CallCenter",
                column: "AdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_ApplicationTypeId",
                table: "Main.CallCenter",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_DepartmentId",
                table: "Main.CallCenter",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_EmployerId",
                table: "Main.CallCenter",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_ExcludedBy",
                table: "Main.CallCenter",
                column: "ExcludedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Main.CallCenter_RegionId",
                table: "Main.CallCenter",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Debitors_ChannelId",
                table: "Main.Debitors",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Debitors_ExcludedBy",
                table: "Main.Debitors",
                column: "ExcludedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Debitors_ResultId",
                table: "Main.Debitors",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Debitors_StatusId",
                table: "Main.Debitors",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.UserChannels_СhannelId",
                table: "Main.UserChannels",
                column: "СhannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.UserChannels_UserId",
                table: "Main.UserChannels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Uzadilmas_ChannelId",
                table: "Main.Uzadilmas",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Uzadilmas_DepartmentId",
                table: "Main.Uzadilmas",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Main.Uzadilmas_RegionId",
                table: "Main.Uzadilmas",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rel.Departments_AdministrationId",
                table: "Rel.Departments",
                column: "AdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rel.Employers_DepartmentId",
                table: "Rel.Employers",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List.SubResults");

            migrationBuilder.DropTable(
                name: "Main.CallCenter");

            migrationBuilder.DropTable(
                name: "Main.Debitors");

            migrationBuilder.DropTable(
                name: "Main.UserChannels");

            migrationBuilder.DropTable(
                name: "Main.Uzadilmas");

            migrationBuilder.DropTable(
                name: "List.ApplicationTypes");

            migrationBuilder.DropTable(
                name: "Rel.Employers");

            migrationBuilder.DropTable(
                name: "List.Results");

            migrationBuilder.DropTable(
                name: "List.Statuses");

            migrationBuilder.DropTable(
                name: "Main.Users");

            migrationBuilder.DropTable(
                name: "List.Regions");

            migrationBuilder.DropTable(
                name: "Main.Сhannels");

            migrationBuilder.DropTable(
                name: "Rel.Departments");

            migrationBuilder.DropTable(
                name: "Rel.Administrations");
        }
    }
}
