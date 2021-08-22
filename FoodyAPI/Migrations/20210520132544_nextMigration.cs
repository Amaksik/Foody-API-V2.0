using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodyAPI.Migrations
{
    public partial class nextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Productid",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Userid",
                table: "Product",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Userid",
                table: "Product",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_Userid",
                table: "Product",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_Userid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Userid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Productid",
                table: "Users",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
