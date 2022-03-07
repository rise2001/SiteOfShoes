using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddNullableShoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_TypesOfDestination_TypeOfDestinationId",
                table: "Shoes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfDestinationId",
                table: "Shoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_TypesOfDestination_TypeOfDestinationId",
                table: "Shoes",
                column: "TypeOfDestinationId",
                principalTable: "TypesOfDestination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_TypesOfDestination_TypeOfDestinationId",
                table: "Shoes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfDestinationId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_TypesOfDestination_TypeOfDestinationId",
                table: "Shoes",
                column: "TypeOfDestinationId",
                principalTable: "TypesOfDestination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
