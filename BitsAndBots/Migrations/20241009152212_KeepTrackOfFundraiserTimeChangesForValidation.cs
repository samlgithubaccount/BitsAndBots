using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitsAndBots.Migrations
{
    /// <inheritdoc />
    public partial class KeepTrackOfFundraiserTimeChangesForValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExistingEndTime",
                table: "Fundraiser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExistingStartTime",
                table: "Fundraiser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExistingEndTime",
                table: "Fundraiser");

            migrationBuilder.DropColumn(
                name: "ExistingStartTime",
                table: "Fundraiser");
        }
    }
}
