using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class AddReferenceQui2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Candidats_CandidatId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Tests_TestId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Answer_AnswerId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_TestId",
                table: "Answers",
                newName: "IX_Answers_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_CandidatId",
                table: "Answers",
                newName: "IX_Answers_CandidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Candidats_CandidatId",
                table: "Answers",
                column: "CandidatId",
                principalTable: "Candidats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Tests_TestId",
                table: "Answers",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Answers_AnswerId",
                table: "Rating",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Candidats_CandidatId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Tests_TestId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Answers_AnswerId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_TestId",
                table: "Answer",
                newName: "IX_Answer_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_CandidatId",
                table: "Answer",
                newName: "IX_Answer_CandidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Candidats_CandidatId",
                table: "Answer",
                column: "CandidatId",
                principalTable: "Candidats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Tests_TestId",
                table: "Answer",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Answer_AnswerId",
                table: "Rating",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
