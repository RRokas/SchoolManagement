using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class thirdIteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Lectures_LectureId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LectureId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Departments");

            migrationBuilder.CreateTable(
                name: "DepartmentLecture",
                columns: table => new
                {
                    DepartmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeptLecturesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLecture", x => new { x.DepartmentsId, x.DeptLecturesId });
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Lectures_DeptLecturesId",
                        column: x => x.DeptLecturesId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLecture_DeptLecturesId",
                table: "DepartmentLecture",
                column: "DeptLecturesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLecture");

            migrationBuilder.AddColumn<Guid>(
                name: "LectureId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LectureId",
                table: "Departments",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Lectures_LectureId",
                table: "Departments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
