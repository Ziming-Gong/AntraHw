using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onboarding.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeCategories",
                columns: table => new
                {
                    LookUpCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCategories", x => x.LookUpCode);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    LookUpdCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ABBR = table.Column<string>(type: "nvarchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.LookUpdCode);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    LookUpCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    ABBR = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatus", x => x.LookUpCode);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCategoryCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatusCode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeCategories_EmployeeCategoryCode",
                        column: x => x.EmployeeCategoryCode,
                        principalTable: "EmployeeCategories",
                        principalColumn: "LookUpCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "LookUpdCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeStatus_EmployeeStatusCode",
                        column: x => x.EmployeeStatusCode,
                        principalTable: "EmployeeStatus",
                        principalColumn: "LookUpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeCategoryCode",
                table: "Employee",
                column: "EmployeeCategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeRoleId",
                table: "Employee",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStatusCode",
                table: "Employee",
                column: "EmployeeStatusCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeCategories");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");
        }
    }
}
