using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddSizeInCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeOfProductId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_SizeOfProductId",
                table: "CartItems",
                column: "SizeOfProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_SizesOfShoe_SizeOfProductId",
                table: "CartItems",
                column: "SizeOfProductId",
                principalTable: "SizesOfShoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_SizesOfShoe_SizeOfProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_SizeOfProductId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "SizeOfProductId",
                table: "CartItems");
        }
    }
}
