using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentMangementSystem.Migrations
{
    /// <inheritdoc />
    public partial class newDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentDtoId",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InrollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryOrder = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StudyYearId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDto_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDto_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDto_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDto_StudyYears_StudyYearId",
                        column: x => x.StudyYearId,
                        principalTable: "StudyYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentDtoId",
                table: "StudentSubjects",
                column: "StudentDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDto_DepartmentId",
                table: "StudentDto",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDto_SportId",
                table: "StudentDto",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDto_StatusId",
                table: "StudentDto",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDto_StudyYearId",
                table: "StudentDto",
                column: "StudyYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_StudentDto_StudentDtoId",
                table: "StudentSubjects",
                column: "StudentDtoId",
                principalTable: "StudentDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_StudentDto_StudentDtoId",
                table: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "StudentDto");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentDtoId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudentDtoId",
                table: "StudentSubjects");
        }
    }
}
