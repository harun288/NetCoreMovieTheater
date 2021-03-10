using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreMovieTheater.Migrations
{
    public partial class weekSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeekId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SessionTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FirstDay = table.Column<DateTime>(nullable: false),
                    LastDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SessionId",
                table: "Reservations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_WeekId",
                table: "Reservations",
                column: "WeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Sessions_SessionId",
                table: "Reservations",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Weeks_WeekId",
                table: "Reservations",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Sessions_SessionId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Weeks_WeekId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SessionId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_WeekId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WeekId",
                table: "Reservations");
        }
    }
}
