using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentMangementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedhashAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Student");
        }
    }
}
