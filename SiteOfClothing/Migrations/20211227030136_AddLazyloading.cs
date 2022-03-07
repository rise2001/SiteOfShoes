using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class AddLazyloading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleID",
                table: "Roles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleID",
                table: "Roles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleID",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Roles");
        }
    }
}
