using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaffemaschine.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kaffeemaschine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wasser = table.Column<double>(type: "REAL", nullable: false),
                    Kaffebohnen = table.Column<double>(type: "REAL", nullable: false),
                    GesamtMengeKaffeProduziert = table.Column<double>(type: "REAL", nullable: false),
                    Temperatur = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaffeemaschine", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kaffeemaschine");
        }
    }
}
