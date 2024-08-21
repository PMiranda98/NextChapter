using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovetheDatepropAddtheCreatedAtandEndedAtproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Offers",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "Offers",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Offers",
                newName: "Date");
        }
    }
}
