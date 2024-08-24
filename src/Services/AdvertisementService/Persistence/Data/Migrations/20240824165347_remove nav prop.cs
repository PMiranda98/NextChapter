using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class removenavprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Advertisements_AdvertisementId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_AdvertisementId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Item");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Advertisements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_ItemId",
                table: "Advertisements",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Item_ItemId",
                table: "Advertisements",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Item_ItemId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_ItemId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Advertisements");

            migrationBuilder.AddColumn<Guid>(
                name: "AdvertisementId",
                table: "Item",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Item_AdvertisementId",
                table: "Item",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Advertisements_AdvertisementId",
                table: "Item",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
