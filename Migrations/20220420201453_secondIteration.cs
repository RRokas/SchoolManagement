using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class secondIteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Students_StudentId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_StudentId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Lectures");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_StudentId",
                table: "Lectures",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Students_StudentId",
                table: "Lectures",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
