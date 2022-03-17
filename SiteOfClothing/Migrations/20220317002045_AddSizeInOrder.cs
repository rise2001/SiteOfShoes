using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddSizeInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeOfProductId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SizeOfProductId",
                table: "OrderItems",
                column: "SizeOfProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_SizesOfShoe_SizeOfProductId",
                table: "OrderItems",
                column: "SizeOfProductId",
                principalTable: "SizesOfShoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_SizesOfShoe_SizeOfProductId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_SizeOfProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SizeOfProductId",
                table: "OrderItems");
        }
    }
}
