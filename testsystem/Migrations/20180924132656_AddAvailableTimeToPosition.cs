using Microsoft.EntityFrameworkCore.Migrations;

namespace testsystem.Migrations
{
    public partial class AddAvailableTimeToPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AvailableTime",
                table: "Positions",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableTime",
                table: "Positions");
        }
    }
}
