using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class BuildUpRelations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositonId",
                table: "Viewers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viewers_PositonId",
                table: "Viewers",
                column: "PositonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viewers_Positions_PositonId",
                table: "Viewers",
                column: "PositonId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viewers_Positions_PositonId",
                table: "Viewers");

            migrationBuilder.DropIndex(
                name: "IX_Viewers_PositonId",
                table: "Viewers");

            migrationBuilder.DropColumn(
                name: "PositonId",
                table: "Viewers");
        }
    }
}
