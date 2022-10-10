using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS_Demo.Data.Migrations
{
    public partial class addR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Lecturers_LecturerID",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "LecturerID",
                table: "Results",
                newName: "ModuleID");

            migrationBuilder.RenameIndex(
                name: "IX_Results_LecturerID",
                table: "Results",
                newName: "IX_Results_ModuleID");

            migrationBuilder.AddColumn<int>(
                name: "LecturerStudentID",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_LecturerStudentID",
                table: "Results",
                column: "LecturerStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Lecturers_LecturerStudentID",
                table: "Results",
                column: "LecturerStudentID",
                principalTable: "Lecturers",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Modules_ModuleID",
                table: "Results",
                column: "ModuleID",
                principalTable: "Modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Lecturers_LecturerStudentID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Modules_ModuleID",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_LecturerStudentID",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "LecturerStudentID",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "ModuleID",
                table: "Results",
                newName: "LecturerID");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ModuleID",
                table: "Results",
                newName: "IX_Results_LecturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Lecturers_LecturerID",
                table: "Results",
                column: "LecturerID",
                principalTable: "Lecturers",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
