using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class updatedGoalAndFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal");

            migrationBuilder.AlterColumn<Guid>(
                name: "folder_id",
                table: "goal",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "folder_data_model_id",
                table: "folder",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_id",
                table: "folder",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_folder_folder_data_model_id",
                table: "folder",
                column: "folder_data_model_id");

            migrationBuilder.AddForeignKey(
                name: "fk_folder_folder_folder_data_model_id",
                table: "folder",
                column: "folder_data_model_id",
                principalTable: "folder",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal",
                column: "folder_id",
                principalTable: "folder",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_folder_folder_folder_data_model_id",
                table: "folder");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal");

            migrationBuilder.DropIndex(
                name: "ix_folder_folder_data_model_id",
                table: "folder");

            migrationBuilder.DropColumn(
                name: "folder_data_model_id",
                table: "folder");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "folder");

            migrationBuilder.AlterColumn<Guid>(
                name: "folder_id",
                table: "goal",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal",
                column: "folder_id",
                principalTable: "folder",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
