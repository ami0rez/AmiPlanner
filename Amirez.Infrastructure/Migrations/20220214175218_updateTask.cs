using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class updateTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "completed",
                table: "task",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "task",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "estimated",
                table: "task",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rest",
                table: "task",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completed",
                table: "task");

            migrationBuilder.DropColumn(
                name: "description",
                table: "task");

            migrationBuilder.DropColumn(
                name: "estimated",
                table: "task");

            migrationBuilder.DropColumn(
                name: "rest",
                table: "task");
        }
    }
}
