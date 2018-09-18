using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class AddReferenceQuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Tests_TestId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_TestId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Rating");

            migrationBuilder.AddColumn<Guid>(
                name: "Reference",
                table: "Answer",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Rating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TestId",
                table: "Rating",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Tests_TestId",
                table: "Rating",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
