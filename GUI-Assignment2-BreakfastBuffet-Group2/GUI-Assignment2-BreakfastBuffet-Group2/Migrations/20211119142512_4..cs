using Microsoft.EntityFrameworkCore.Migrations;

namespace BreakfastBuffet2.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestGuest",
                columns: table => new
                {
                    BookedGuestsGuestId = table.Column<int>(type: "int", nullable: false),
                    CheckedInGuestsGuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestGuest", x => new { x.BookedGuestsGuestId, x.CheckedInGuestsGuestId });
                    table.ForeignKey(
                        name: "FK_GuestGuest_Guest_BookedGuestsGuestId",
                        column: x => x.BookedGuestsGuestId,
                        principalTable: "Guest",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestGuest_Guest_CheckedInGuestsGuestId",
                        column: x => x.CheckedInGuestsGuestId,
                        principalTable: "Guest",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestGuest_CheckedInGuestsGuestId",
                table: "GuestGuest",
                column: "CheckedInGuestsGuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestGuest");
        }
    }
}
