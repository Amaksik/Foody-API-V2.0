using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodyAPI.Migrations
{
    public partial class StatisticsForUsersUpdatedX2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DayIntake_intakeid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_intakeid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "intakeid",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "intakeid",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_intakeid",
                table: "Users",
                column: "intakeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DayIntake_intakeid",
                table: "Users",
                column: "intakeid",
                principalTable: "DayIntake",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
