using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class SizeToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeSizeOfShoe");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SizesOfShoe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeOfShoeId1",
                table: "Shoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SizesOfShoe_ProductId",
                table: "SizesOfShoe",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SizeOfShoeId1",
                table: "Shoes",
                column: "SizeOfShoeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_SizesOfShoe_SizeOfShoeId1",
                table: "Shoes",
                column: "SizeOfShoeId1",
                principalTable: "SizesOfShoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SizesOfShoe_Products_ProductId",
                table: "SizesOfShoe",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_SizesOfShoe_SizeOfShoeId1",
                table: "Shoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SizesOfShoe_Products_ProductId",
                table: "SizesOfShoe");

            migrationBuilder.DropIndex(
                name: "IX_SizesOfShoe_ProductId",
                table: "SizesOfShoe");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_SizeOfShoeId1",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SizesOfShoe");

            migrationBuilder.DropColumn(
                name: "SizeOfShoeId1",
                table: "Shoes");

            migrationBuilder.CreateTable(
                name: "ShoeSizeOfShoe",
                columns: table => new
                {
                    ShoesId = table.Column<int>(type: "int", nullable: false),
                    SizesOfShoeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSizeOfShoe", x => new { x.ShoesId, x.SizesOfShoeId });
                    table.ForeignKey(
                        name: "FK_ShoeSizeOfShoe_Shoes_ShoesId",
                        column: x => x.ShoesId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeSizeOfShoe_SizesOfShoe_SizesOfShoeId",
                        column: x => x.SizesOfShoeId,
                        principalTable: "SizesOfShoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizeOfShoe_SizesOfShoeId",
                table: "ShoeSizeOfShoe",
                column: "SizesOfShoeId");
        }
    }
}
