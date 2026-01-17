using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentMangementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedhash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Student",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Student",
                newName: "Password");
        }
    }
}
