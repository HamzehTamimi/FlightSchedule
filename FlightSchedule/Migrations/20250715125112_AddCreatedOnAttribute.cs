using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightSchedule.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedOnAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Airlines",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Airlines");
        }
    }
}
