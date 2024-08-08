using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class PhotoclassaddedtotheItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "Item",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_PhotoId",
                table: "Item",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Photo_PhotoId",
                table: "Item",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Photo_PhotoId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Item_PhotoId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Item",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
