using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffeten_GruppeTo.Migrations
{
    public partial class opdatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_breakfastBuffets_BreakfastBuffetDBReceptiontId",
                table: "guests");

            migrationBuilder.DropForeignKey(
                name: "FK_guests_breakfastBuffets_BreakfastBuffetDBReceptiontId1",
                table: "guests");

            migrationBuilder.DropIndex(
                name: "IX_guests_BreakfastBuffetDBReceptiontId",
                table: "guests");

            migrationBuilder.DropIndex(
                name: "IX_guests_BreakfastBuffetDBReceptiontId1",
                table: "guests");

            migrationBuilder.DropColumn(
                name: "BreakfastBuffetDBReceptiontId",
                table: "guests");

            migrationBuilder.DropColumn(
                name: "BreakfastBuffetDBReceptiontId1",
                table: "guests");

            migrationBuilder.RenameColumn(
                name: "ReceptiontId",
                table: "breakfastBuffets",
                newName: "BreakfastBuffetDBId");

            migrationBuilder.AlterColumn<bool>(
                name: "ChildCount",
                table: "guests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "AdultCount",
                table: "guests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BreakfastBuffetDBId",
                table: "guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_guests_BreakfastBuffetDBId",
                table: "guests",
                column: "BreakfastBuffetDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_breakfastBuffets_BreakfastBuffetDBId",
                table: "guests",
                column: "BreakfastBuffetDBId",
                principalTable: "breakfastBuffets",
                principalColumn: "BreakfastBuffetDBId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_breakfastBuffets_BreakfastBuffetDBId",
                table: "guests");

            migrationBuilder.DropIndex(
                name: "IX_guests_BreakfastBuffetDBId",
                table: "guests");

            migrationBuilder.DropColumn(
                name: "BreakfastBuffetDBId",
                table: "guests");

            migrationBuilder.RenameColumn(
                name: "BreakfastBuffetDBId",
                table: "breakfastBuffets",
                newName: "ReceptiontId");

            migrationBuilder.AlterColumn<int>(
                name: "ChildCount",
                table: "guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "AdultCount",
                table: "guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "BreakfastBuffetDBReceptiontId",
                table: "guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreakfastBuffetDBReceptiontId1",
                table: "guests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_guests_BreakfastBuffetDBReceptiontId",
                table: "guests",
                column: "BreakfastBuffetDBReceptiontId");

            migrationBuilder.CreateIndex(
                name: "IX_guests_BreakfastBuffetDBReceptiontId1",
                table: "guests",
                column: "BreakfastBuffetDBReceptiontId1");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_breakfastBuffets_BreakfastBuffetDBReceptiontId",
                table: "guests",
                column: "BreakfastBuffetDBReceptiontId",
                principalTable: "breakfastBuffets",
                principalColumn: "ReceptiontId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_guests_breakfastBuffets_BreakfastBuffetDBReceptiontId1",
                table: "guests",
                column: "BreakfastBuffetDBReceptiontId1",
                principalTable: "breakfastBuffets",
                principalColumn: "ReceptiontId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
