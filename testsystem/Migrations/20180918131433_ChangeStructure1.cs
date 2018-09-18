using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class ChangeStructure1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Rating",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CandidatId = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AnswerId",
                table: "Rating",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_CandidatId",
                table: "Answer",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_TestId",
                table: "Answer",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Answer_AnswerId",
                table: "Rating",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Answer_AnswerId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Rating_AnswerId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Tests",
                nullable: true);
        }
    }
}
