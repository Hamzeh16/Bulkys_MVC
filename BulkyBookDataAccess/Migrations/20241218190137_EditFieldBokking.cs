using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditFieldBokking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookingPages",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "BookingPages",
                newName: "User_Name");

            migrationBuilder.AddColumn<int>(
                name: "IDNumber",
                table: "BookingPages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Requst",
                table: "BookingPages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Email",
                table: "BookingPages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "BookingPages");

            migrationBuilder.DropColumn(
                name: "Requst",
                table: "BookingPages");

            migrationBuilder.DropColumn(
                name: "User_Email",
                table: "BookingPages");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BookingPages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "User_Name",
                table: "BookingPages",
                newName: "email");
        }
    }
}
