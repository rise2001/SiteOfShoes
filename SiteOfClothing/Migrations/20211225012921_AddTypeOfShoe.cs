using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddTypeOfShoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfShoeId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypesOfShoe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfShoe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_TypeOfShoeId",
                table: "Shoes",
                column: "TypeOfShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_TypesOfShoe_TypeOfShoeId",
                table: "Shoes",
                column: "TypeOfShoeId",
                principalTable: "TypesOfShoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_TypesOfShoe_TypeOfShoeId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "TypesOfShoe");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_TypeOfShoeId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "TypeOfShoeId",
                table: "Shoes");
        }
    }
}
