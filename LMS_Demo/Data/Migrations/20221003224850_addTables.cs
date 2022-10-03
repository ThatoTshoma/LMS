using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS_Demo.Data.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssesmentTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssesmentTypes", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyID);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    YearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Lecturers_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionID);
                    table.ForeignKey(
                        name: "FK_Sections_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyID = table.Column<int>(type: "int", nullable: true),
                    YearID = table.Column<int>(type: "int", nullable: true),
                    LecturerStudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK_Modules_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Lecturers_LecturerStudentID",
                        column: x => x.LecturerStudentID,
                        principalTable: "Lecturers",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyID = table.Column<int>(type: "int", nullable: true),
                    SectionID = table.Column<int>(type: "int", nullable: true),
                    YearID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssesmentAttachments",
                columns: table => new
                {
                    AttachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeID = table.Column<int>(type: "int", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SectionID = table.Column<int>(type: "int", nullable: true),
                    FacultyID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    YearID = table.Column<int>(type: "int", nullable: true),
                    LectureID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssesmentTypeTypeID = table.Column<int>(type: "int", nullable: true),
                    LecturerStudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssesmentAttachments", x => x.AttachID);
                    table.ForeignKey(
                        name: "FK_AssesmentAttachments_AssesmentTypes_AssesmentTypeTypeID",
                        column: x => x.AssesmentTypeTypeID,
                        principalTable: "AssesmentTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssesmentAttachments_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssesmentAttachments_Lecturers_LecturerStudentID",
                        column: x => x.LecturerStudentID,
                        principalTable: "Lecturers",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssesmentAttachments_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssesmentAttachments_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssesmentAttachments_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assesments",
                columns: table => new
                {
                    AssesmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssesmentTypeID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    FacultyID = table.Column<int>(type: "int", nullable: true),
                    SectionID = table.Column<int>(type: "int", nullable: true),
                    YearID = table.Column<int>(type: "int", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMark = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LecturerStudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesments", x => x.AssesmentID);
                    table.ForeignKey(
                        name: "FK_Assesments_AssesmentTypes_AssesmentTypeID",
                        column: x => x.AssesmentTypeID,
                        principalTable: "AssesmentTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesments_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesments_Lecturers_LecturerStudentID",
                        column: x => x.LecturerStudentID,
                        principalTable: "Lecturers",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesments_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesments_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assesments_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    TeachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    FacultyID = table.Column<int>(type: "int", nullable: true),
                    YearID = table.Column<int>(type: "int", nullable: true),
                    SectionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaches", x => x.TeachID);
                    table.ForeignKey(
                        name: "FK_Teaches_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teaches_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teaches_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teaches_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teaches_Years_YearID",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerStudent",
                columns: table => new
                {
                    LecturersStudentID = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerStudent", x => new { x.LecturersStudentID, x.StudentsStudentID });
                    table.ForeignKey(
                        name: "FK_LecturerStudent_Lecturers_LecturersStudentID",
                        column: x => x.LecturersStudentID,
                        principalTable: "Lecturers",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerStudent_Students_StudentsStudentID",
                        column: x => x.StudentsStudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    LecturerID = table.Column<int>(type: "int", nullable: true),
                    AssesmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_Results_Assesments_AssesmentID",
                        column: x => x.AssesmentID,
                        principalTable: "Assesments",
                        principalColumn: "AssesmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Results_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmitAssignment",
                columns: table => new
                {
                    SubmitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    AssesmentID = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmitAssignment", x => x.SubmitID);
                    table.ForeignKey(
                        name: "FK_SubmitAssignment_Assesments_AssesmentID",
                        column: x => x.AssesmentID,
                        principalTable: "Assesments",
                        principalColumn: "AssesmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmitAssignment_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentAttachments_AssesmentTypeTypeID",
                table: "AssesmentAttachments",
                column: "AssesmentTypeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentAttachments_FacultyID",
                table: "AssesmentAttachments",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentAttachments_LecturerStudentID",
                table: "AssesmentAttachments",
                column: "LecturerStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentAttachments_ModuleID",
                table: "AssesmentAttachments",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentAttachments_SectionID",
                table: "AssesmentAttachments",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_AssesmentAttachments_YearID",
                table: "AssesmentAttachments",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_AssesmentTypeID",
                table: "Assesments",
                column: "AssesmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_FacultyID",
                table: "Assesments",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_LecturerStudentID",
                table: "Assesments",
                column: "LecturerStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_ModuleID",
                table: "Assesments",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_SectionID",
                table: "Assesments",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Assesments_YearID",
                table: "Assesments",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_FacultyID",
                table: "Lecturers",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerStudent_StudentsStudentID",
                table: "LecturerStudent",
                column: "StudentsStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_FacultyID",
                table: "Modules",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_LecturerStudentID",
                table: "Modules",
                column: "LecturerStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_YearID",
                table: "Modules",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_AssesmentID",
                table: "Results",
                column: "AssesmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_LecturerID",
                table: "Results",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentID",
                table: "Results",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_YearID",
                table: "Sections",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyID",
                table: "Students",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SectionID",
                table: "Students",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_YearID",
                table: "Students",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_SubmitAssignment_AssesmentID",
                table: "SubmitAssignment",
                column: "AssesmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubmitAssignment_StudentID",
                table: "SubmitAssignment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_FacultyID",
                table: "Teaches",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_LecturerID",
                table: "Teaches",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_ModuleID",
                table: "Teaches",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_SectionID",
                table: "Teaches",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_YearID",
                table: "Teaches",
                column: "YearID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssesmentAttachments");

            migrationBuilder.DropTable(
                name: "LecturerStudent");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "SubmitAssignment");

            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.DropTable(
                name: "Assesments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AssesmentTypes");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
