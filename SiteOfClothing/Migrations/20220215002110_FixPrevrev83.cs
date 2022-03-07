using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteOfShoes.Migrations
{
    public partial class FixPrevrev83 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserID1",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UserID1",
                table: "Carts",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserID1",
                table: "Carts",
                newName: "IX_Carts_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserID",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Carts",
                newName: "UserID1");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                newName: "IX_Carts_UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserID1",
                table: "Carts",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
