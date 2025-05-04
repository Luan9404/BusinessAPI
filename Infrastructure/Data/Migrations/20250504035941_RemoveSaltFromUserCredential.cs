using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessAPI.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSaltFromUserCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "UserCredential");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "UserCredential",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
