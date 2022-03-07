using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddProductEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isSaled = table.Column<bool>(type: "bit", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizesOfShoe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizesOfShoe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfDestination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfDestination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfSeason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfSeason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfSex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfSex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostOfProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TimeOfCost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostOfProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostOfProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfSeasonId = table.Column<int>(type: "int", nullable: false),
                    TypeOfSexId = table.Column<int>(type: "int", nullable: false),
                    TypeOfDestinationId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoes_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shoes_TypesOfDestination_TypeOfDestinationId",
                        column: x => x.TypeOfDestinationId,
                        principalTable: "TypesOfDestination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_TypesOfSeason_TypeOfSeasonId",
                        column: x => x.TypeOfSeasonId,
                        principalTable: "TypesOfSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_TypesOfSex_TypeOfSexId",
                        column: x => x.TypeOfSexId,
                        principalTable: "TypesOfSex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "SizesOfShoe",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 17, "17" },
                    { 41, "41" },
                    { 43, "43" },
                    { 44, "44" },
                    { 45, "45" },
                    { 46, "46" },
                    { 47, "47" },
                    { 48, "48" },
                    { 49, "49" },
                    { 50, "50" },
                    { 51, "51" },
                    { 52, "52" },
                    { 53, "53" },
                    { 54, "54" },
                    { 55, "55" },
                    { 56, "56" },
                    { 57, "57" },
                    { 58, "58" },
                    { 59, "59" },
                    { 60, "60" },
                    { 40, "40" },
                    { 39, "39" },
                    { 42, "42" },
                    { 37, "37" },
                    { 18, "18" },
                    { 19, "19" },
                    { 20, "20" },
                    { 21, "21" },
                    { 22, "22" },
                    { 23, "23" },
                    { 38, "38" },
                    { 25, "25" },
                    { 26, "26" },
                    { 27, "27" },
                    { 24, "24" },
                    { 29, "29" },
                    { 28, "28" },
                    { 35, "35" },
                    { 34, "34" },
                    { 36, "36" },
                    { 32, "32" },
                    { 31, "31" }
                });

            migrationBuilder.InsertData(
                table: "SizesOfShoe",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 30, "30" },
                    { 33, "33" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfSeason",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Зимняя" },
                    { 2, "Летняя" },
                    { 3, "Осенняя" },
                    { 4, "Весенняя" },
                    { 5, "Всесезонная" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfSex",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Женский" },
                    { 1, "Мужской" },
                    { 3, "Унисекс" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostOfProducts_ProductId",
                table: "CostOfProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeAndSizes_SizeOfShoeId",
                table: "ShoeAndSizes",
                column: "SizeOfShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_TypeOfDestinationId",
                table: "Shoes",
                column: "TypeOfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_TypeOfSeasonId",
                table: "Shoes",
                column: "TypeOfSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_TypeOfSexId",
                table: "Shoes",
                column: "TypeOfSexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostOfProducts");

            migrationBuilder.DropTable(
                name: "ShoeAndSizes");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "SizesOfShoe");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TypesOfDestination");

            migrationBuilder.DropTable(
                name: "TypesOfSeason");

            migrationBuilder.DropTable(
                name: "TypesOfSex");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
