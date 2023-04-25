using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                table: "JobRequirements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionStatus",
                columns: table => new
                {
                    LookUpCode = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionStatus", x => x.LookUpCode);
                    table.ForeignKey(
                        name: "FK_SubmissionStatus_Submission_LookUpCode",
                        column: x => x.LookUpCode,
                        principalTable: "Submission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRequirementType",
                columns: table => new
                {
                    JobRequirementId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequirementType", x => new { x.EmployeeTypeId, x.JobRequirementId });
                    table.ForeignKey(
                        name: "FK_EmployeeRequirementType_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRequirementType_JobRequirements_JobRequirementId",
                        column: x => x.JobRequirementId,
                        principalTable: "JobRequirements",
                        principalColumn: "JobRequirementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_JobCategoryId",
                table: "JobRequirements",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequirementType_JobRequirementId",
                table: "EmployeeRequirementType",
                column: "JobRequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirements_JobCategory_JobCategoryId",
                table: "JobRequirements",
                column: "JobCategoryId",
                principalTable: "JobCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirements_JobCategory_JobCategoryId",
                table: "JobRequirements");

            migrationBuilder.DropTable(
                name: "EmployeeRequirementType");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "SubmissionStatus");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropIndex(
                name: "IX_JobRequirements_JobCategoryId",
                table: "JobRequirements");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "JobRequirements");
        }
    }
}
