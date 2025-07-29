using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class categoryentityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assets_AssetCategory_CategoryId",
                table: "assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetCategory",
                table: "AssetCategory");

            migrationBuilder.RenameTable(
                name: "AssetCategory",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assets_categories_CategoryId",
                table: "assets",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assets_categories_CategoryId",
                table: "assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "AssetCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetCategory",
                table: "AssetCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assets_AssetCategory_CategoryId",
                table: "assets",
                column: "CategoryId",
                principalTable: "AssetCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
