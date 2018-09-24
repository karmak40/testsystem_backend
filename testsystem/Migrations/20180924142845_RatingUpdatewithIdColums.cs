using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class RatingUpdatewithIdColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Answers_AnswerId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Viewers_ViewerId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_ViewerId",
                table: "Ratings",
                newName: "IX_Ratings_ViewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_AnswerId",
                table: "Ratings",
                newName: "IX_Ratings_AnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "ViewerId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Answers_AnswerId",
                table: "Ratings",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Viewers_ViewerId",
                table: "Ratings",
                column: "ViewerId",
                principalTable: "Viewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Answers_AnswerId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Viewers_ViewerId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ViewerId",
                table: "Rating",
                newName: "IX_Rating_ViewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_AnswerId",
                table: "Rating",
                newName: "IX_Rating_AnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "ViewerId",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Answers_AnswerId",
                table: "Rating",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Viewers_ViewerId",
                table: "Rating",
                column: "ViewerId",
                principalTable: "Viewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
