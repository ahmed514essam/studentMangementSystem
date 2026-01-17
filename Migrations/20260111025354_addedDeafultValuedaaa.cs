using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace studentMangementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedDeafultValuedaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "StudentDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "StudentDto");
        }
    }
}
