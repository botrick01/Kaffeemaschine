using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaffemaschine.Migrations
{
    public partial class addTemperatur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Temperatur",
                table: "Kaffeemaschine",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperatur",
                table: "Kaffeemaschine");
        }
    }
}
