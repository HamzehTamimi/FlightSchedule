using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchedule.Migrations
{
    /// <inheritdoc />
    public partial class MapAirlineToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airlines");
        }
    }
}
