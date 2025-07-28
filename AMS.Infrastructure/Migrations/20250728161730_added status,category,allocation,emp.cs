using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedstatuscategoryallocationemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "assets");

            migrationBuilder.AddColumn<int>(
                name: "AllocatedTo",
                table: "assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "assets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AssetCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assets_AllocatedTo",
                table: "assets",
                column: "AllocatedTo");

            migrationBuilder.CreateIndex(
                name: "IX_assets_CategoryId",
                table: "assets",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_assets_AssetCategory_CategoryId",
                table: "assets",
                column: "CategoryId",
                principalTable: "AssetCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assets_employees_AllocatedTo",
                table: "assets",
                column: "AllocatedTo",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assets_AssetCategory_CategoryId",
                table: "assets");

            migrationBuilder.DropForeignKey(
                name: "FK_assets_employees_AllocatedTo",
                table: "assets");

            migrationBuilder.DropTable(
                name: "AssetCategory");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropIndex(
                name: "IX_assets_AllocatedTo",
                table: "assets");

            migrationBuilder.DropIndex(
                name: "IX_assets_CategoryId",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "AllocatedTo",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "assets");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
