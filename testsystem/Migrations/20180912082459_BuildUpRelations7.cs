using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class BuildUpRelations7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viewers_Positions_PositonId",
                table: "Viewers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "PositonId",
                table: "Viewers",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Viewers_PositonId",
                table: "Viewers",
                newName: "IX_Viewers_PositionId");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Viewers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Positions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Candidats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Viewers_Positions_PositionId",
                table: "Viewers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viewers_Positions_PositionId",
                table: "Viewers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Viewers");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Viewers",
                newName: "PositonId");

            migrationBuilder.RenameIndex(
                name: "IX_Viewers_PositionId",
                table: "Viewers",
                newName: "IX_Viewers_PositonId");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Positions",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Candidats",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Viewers_Positions_PositonId",
                table: "Viewers",
                column: "PositonId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
