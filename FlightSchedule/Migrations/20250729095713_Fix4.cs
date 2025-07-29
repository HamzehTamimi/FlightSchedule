using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchedule.Migrations
{
    /// <inheritdoc />
    public partial class Fix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaxInfos_Flights_FlightId",
                table: "PaxInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaxInfos",
                table: "PaxInfos");

            migrationBuilder.RenameTable(
                name: "PaxInfos",
                newName: "PaxInfo");

            migrationBuilder.RenameIndex(
                name: "IX_PaxInfos_FlightId",
                table: "PaxInfo",
                newName: "IX_PaxInfo_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaxInfo",
                table: "PaxInfo",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaxInfo",
                table: "PaxInfo");

            migrationBuilder.RenameTable(
                name: "PaxInfo",
                newName: "PaxInfos");

            migrationBuilder.RenameIndex(
                name: "IX_PaxInfo_FlightId",
                table: "PaxInfos",
                newName: "IX_PaxInfos_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaxInfos",
                table: "PaxInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaxInfos_Flights_FlightId",
                table: "PaxInfos",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
