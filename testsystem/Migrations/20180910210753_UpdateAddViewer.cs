using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class UpdateAddViewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExpiredDate",
                table: "Candidats",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "InvitationDate",
                table: "Candidats",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Candidats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Viewers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    InvitationDate = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viewers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viewers");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Candidats");

            migrationBuilder.DropColumn(
                name: "InvitationDate",
                table: "Candidats");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Candidats");
        }
    }
}
