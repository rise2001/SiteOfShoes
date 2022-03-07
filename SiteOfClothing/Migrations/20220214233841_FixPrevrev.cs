using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class FixPrevrev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_SizesOfShoe_SizeOfShoeId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_SizeOfShoeId",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartItems_SizeOfShoeId",
                table: "CartItems",
                column: "SizeOfShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_SizesOfShoe_SizeOfShoeId",
                table: "CartItems",
                column: "SizeOfShoeId",
                principalTable: "SizesOfShoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
