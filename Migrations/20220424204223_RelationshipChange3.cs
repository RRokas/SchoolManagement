using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class RelationshipChange3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_LectureId",
                table: "LectureStudent");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "LectureStudent",
                newName: "LecturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesId",
                table: "LectureStudent",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesId",
                table: "LectureStudent");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "LectureStudent",
                newName: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_LectureId",
                table: "LectureStudent",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
