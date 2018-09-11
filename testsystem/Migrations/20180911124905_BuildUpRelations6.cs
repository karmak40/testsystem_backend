using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class BuildUpRelations6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositonId",
                table: "Viewers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Candidats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viewers_PositonId",
                table: "Viewers",
                column: "PositonId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_PositionId",
                table: "Candidats",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidats_Positions_PositionId",
                table: "Candidats",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Candidats_Positions_PositionId",
                table: "Candidats");

            migrationBuilder.DropForeignKey(
                name: "FK_Viewers_Positions_PositonId",
                table: "Viewers");

            migrationBuilder.DropIndex(
                name: "IX_Viewers_PositonId",
                table: "Viewers");

            migrationBuilder.DropIndex(
                name: "IX_Candidats_PositionId",
                table: "Candidats");

            migrationBuilder.DropColumn(
                name: "PositonId",
                table: "Viewers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Candidats");
        }
    }
}
