using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffeten_GruppeTo.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "reception");

            migrationBuilder.CreateTable(
                name: "breakfastBuffets",
                columns: table => new
                {
                    ReceptiontId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breakfastBuffets", x => x.ReceptiontId);
                });

            migrationBuilder.CreateTable(
                name: "guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdultCount = table.Column<int>(type: "int", nullable: false),
                    ChildCount = table.Column<int>(type: "int", nullable: false),
                    BreakfastBuffetDBReceptiontId = table.Column<int>(type: "int", nullable: true),
                    BreakfastBuffetDBReceptiontId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guests", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_guests_breakfastBuffets_BreakfastBuffetDBReceptiontId",
                        column: x => x.BreakfastBuffetDBReceptiontId,
                        principalTable: "breakfastBuffets",
                        principalColumn: "ReceptiontId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guests_breakfastBuffets_BreakfastBuffetDBReceptiontId1",
                        column: x => x.BreakfastBuffetDBReceptiontId1,
                        principalTable: "breakfastBuffets",
                        principalColumn: "ReceptiontId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guests_BreakfastBuffetDBReceptiontId",
                table: "guests",
                column: "BreakfastBuffetDBReceptiontId");

            migrationBuilder.CreateIndex(
                name: "IX_guests_BreakfastBuffetDBReceptiontId1",
                table: "guests",
                column: "BreakfastBuffetDBReceptiontId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guests");

            migrationBuilder.DropTable(
                name: "breakfastBuffets");

            migrationBuilder.CreateTable(
                name: "reception",
                columns: table => new
                {
                    ReceptiontId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception", x => x.ReceptiontId);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdultCount = table.Column<int>(type: "int", nullable: false),
                    ChildCount = table.Column<int>(type: "int", nullable: false),
                    ReceptiontDBReceptiontId = table.Column<int>(type: "int", nullable: true),
                    ReceptiontDBReceptiontId1 = table.Column<int>(type: "int", nullable: true),
                    RoomNbr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guest_reception_ReceptiontDBReceptiontId",
                        column: x => x.ReceptiontDBReceptiontId,
                        principalTable: "reception",
                        principalColumn: "ReceptiontId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guest_reception_ReceptiontDBReceptiontId1",
                        column: x => x.ReceptiontDBReceptiontId1,
                        principalTable: "reception",
                        principalColumn: "ReceptiontId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guest_ReceptiontDBReceptiontId",
                table: "Guest",
                column: "ReceptiontDBReceptiontId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_ReceptiontDBReceptiontId1",
                table: "Guest",
                column: "ReceptiontDBReceptiontId1");
        }
    }
}
