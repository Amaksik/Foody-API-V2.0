using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodyAPI.Migrations
{
    public partial class StatisticsForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "intakeid",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayIntake",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userid = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayIntake", x => x.id);
                    table.ForeignKey(
                        name: "FK_DayIntake_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_intakeid",
                table: "Users",
                column: "intakeid");

            migrationBuilder.CreateIndex(
                name: "IX_DayIntake_userid",
                table: "DayIntake",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DayIntake_intakeid",
                table: "Users",
                column: "intakeid",
                principalTable: "DayIntake",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DayIntake_intakeid",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DayIntake");

            migrationBuilder.DropIndex(
                name: "IX_Users_intakeid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "intakeid",
                table: "Users");
        }
    }
}
