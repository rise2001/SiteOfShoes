using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SalePercent",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalePercent",
                table: "Products");
        }
    }
}
