using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class UpdateFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_folder_folder_folder_data_model_id",
                table: "folder");

            migrationBuilder.DropIndex(
                name: "ix_folder_folder_data_model_id",
                table: "folder");

            migrationBuilder.DropColumn(
                name: "folder_data_model_id",
                table: "folder");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "folder",
                newName: "folder_id");

            migrationBuilder.CreateIndex(
                name: "ix_folder_folder_id",
                table: "folder",
                column: "folder_id");

            migrationBuilder.AddForeignKey(
                name: "fk_folder_folder_folder_id",
                table: "folder",
                column: "folder_id",
                principalTable: "folder",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_folder_folder_folder_id",
                table: "folder");

            migrationBuilder.DropIndex(
                name: "ix_folder_folder_id",
                table: "folder");

            migrationBuilder.RenameColumn(
                name: "folder_id",
                table: "folder",
                newName: "parent_id");

            migrationBuilder.AddColumn<Guid>(
                name: "folder_data_model_id",
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
        }
    }
}
