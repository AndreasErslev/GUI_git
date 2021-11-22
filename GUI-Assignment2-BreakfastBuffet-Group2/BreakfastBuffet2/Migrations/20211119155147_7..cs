using Microsoft.EntityFrameworkCore.Migrations;

namespace BreakfastBuffet2.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Checked_In",
                table: "Guest",
                newName: "Check_In");

            migrationBuilder.RenameColumn(
                name: "Booked",
                table: "Guest",
                newName: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Check_In",
                table: "Guest",
                newName: "Checked_In");

            migrationBuilder.RenameColumn(
                name: "Book",
                table: "Guest",
                newName: "Booked");
        }
    }
}
