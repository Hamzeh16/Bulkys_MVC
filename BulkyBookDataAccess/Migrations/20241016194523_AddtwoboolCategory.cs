using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddtwoboolCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Categories");
        }
    }
}
