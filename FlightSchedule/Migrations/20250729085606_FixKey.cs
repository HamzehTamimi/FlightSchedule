using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchedule.Migrations
{
    /// <inheritdoc />
    public partial class FixKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaxInfo_Flights_AirlineId",
                table: "PaxInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaxInfo_AirlineId",
                table: "PaxInfo");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "PaxInfo");

            migrationBuilder.CreateIndex(
                name: "IX_PaxInfo_FlightId",
                table: "PaxInfo",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaxInfo_Flights_FlightId",
                table: "PaxInfo",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaxInfo_Flights_FlightId",
                table: "PaxInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaxInfo_FlightId",
                table: "PaxInfo");

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "PaxInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaxInfo_AirlineId",
                table: "PaxInfo",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaxInfo_Flights_AirlineId",
                table: "PaxInfo",
                column: "AirlineId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
