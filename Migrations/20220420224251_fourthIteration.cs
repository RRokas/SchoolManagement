using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class fourthIteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_DeptLecturesId",
                table: "DepartmentLecture");

            migrationBuilder.RenameColumn(
                name: "DeptLecturesId",
                table: "DepartmentLecture",
                newName: "LecturesId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_DeptLecturesId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_LecturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "DepartmentLecture",
                newName: "DeptLecturesId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLecture_LecturesId",
                table: "DepartmentLecture",
                newName: "IX_DepartmentLecture_DeptLecturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_DeptLecturesId",
                table: "DepartmentLecture",
                column: "DeptLecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
