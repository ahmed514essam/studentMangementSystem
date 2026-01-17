using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace studentMangementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedDeafultValued : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyYears_Departments_DepartmentId",
                table: "StudyYears");

            migrationBuilder.DropIndex(
                name: "IX_StudyYears_DepartmentId",
                table: "StudyYears");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "StudyYears");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DepartmentStudyYears",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StudyYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentStudyYears", x => new { x.DepartmentId, x.StudyYearId });
                    table.ForeignKey(
                        name: "FK_DepartmentStudyYears_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentStudyYears_StudyYears_StudyYearId",
                        column: x => x.StudyYearId,
                        principalTable: "StudyYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentHead", "Name" },
                values: new object[,]
                {
                    { 1, "Oliver Herston", "Mechanical Engineering" },
                    { 2, "Mike Hary", "Electrical Engineering" },
                    { 3, "Steven Odegard", "Civil Engineering " },
                    { 4, "Jordon Harmi", "Computer Science" },
                    { 5, "Alina Foc", "Management Information Systems" },
                    { 6, "Zendaia ", "Information technology" },
                    { 7, "Sedeny Foler", "business management" },
                    { 8, "Hary Tormy", "Fine Arts" },
                    { 9, "Tom Armorstrong", "Law" },
                    { 10, "Keny Ackremany", "Primary Education" }
                });

            migrationBuilder.InsertData(
                table: "Sport",
                columns: new[] { "Id", "Coach", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe", "Football" },
                    { 2, "Jane Smith", "Basketball" },
                    { 3, "Mike Johnson", "Tennis" }
                });

            migrationBuilder.InsertData(
                table: "StudyYears",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Preparatory Engineering" },
                    { 2, "First Year" },
                    { 3, "Second Year" },
                    { 4, "Third Year" },
                    { 5, "Fourth Year" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Password",
                table: "Student",
                column: "Password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStudyYears_StudyYearId",
                table: "DepartmentStudyYears",
                column: "StudyYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentStudyYears");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Student_Password",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sport",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sport",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sport",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "StudyYears",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudyYears_DepartmentId",
                table: "StudyYears",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyYears_Departments_DepartmentId",
                table: "StudyYears",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
