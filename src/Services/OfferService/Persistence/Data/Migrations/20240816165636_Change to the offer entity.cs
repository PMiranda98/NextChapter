using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changetotheofferentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Buyer",
                table: "Offers",
                newName: "Sender");

            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "Offers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Offers",
                newName: "Buyer");
        }
    }
}
