using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuiEksamenDel2.Data.Migrations
{
    public partial class sessionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(nullable: false),
                    BPM = table.Column<int>(nullable: false),
                    SessionLength = table.Column<int>(nullable: false),
                    Dato = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}
