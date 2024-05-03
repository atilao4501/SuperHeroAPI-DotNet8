using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class passAddedAgencyRoleToo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Agencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Agencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Agencies");
        }
    }
}
