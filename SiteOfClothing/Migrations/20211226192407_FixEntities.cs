using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class FixEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeAndSizes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeSizeOfShoe");

            migrationBuilder.CreateTable(
                name: "ShoeAndSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(type: "int", nullable: false),
                    SizeOfShoeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeAndSizes", x => x.Id);
                    table.UniqueConstraint("AK_ShoeAndSizes_ShoeId_SizeOfShoeId", x => new { x.ShoeId, x.SizeOfShoeId });
                    table.ForeignKey(
                        name: "FK_ShoeAndSizes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeAndSizes_SizesOfShoe_SizeOfShoeId",
                        column: x => x.SizeOfShoeId,
                        principalTable: "SizesOfShoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeAndSizes_SizeOfShoeId",
                table: "ShoeAndSizes",
                column: "SizeOfShoeId");
        }
    }
}
