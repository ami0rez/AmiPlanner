using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class AddHostoryParentItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_history_task_version_id",
                table: "History");

            migrationBuilder.DropIndex(
                name: "ix_history_version_id",
                table: "History");

            migrationBuilder.AlterColumn<Guid>(
                name: "version_id",
                table: "History",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_id",
                table: "History",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "task_data_model_id",
                table: "History",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_history_parent_id",
                table: "History",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_history_task_data_model_id",
                table: "History",
                column: "task_data_model_id");

            migrationBuilder.CreateIndex(
                name: "ix_history_version_id",
                table: "History",
                column: "version_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_history_task_parent_id",
                table: "History",
                column: "parent_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History",
                column: "task_data_model_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_history_task_version_id",
                table: "History",
                column: "version_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_history_task_parent_id",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "fk_history_task_version_id",
                table: "History");

            migrationBuilder.DropIndex(
                name: "ix_history_parent_id",
                table: "History");

            migrationBuilder.DropIndex(
                name: "ix_history_task_data_model_id",
                table: "History");

            migrationBuilder.DropIndex(
                name: "ix_history_version_id",
                table: "History");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "History");

            migrationBuilder.DropColumn(
                name: "task_data_model_id",
                table: "History");

            migrationBuilder.AlterColumn<Guid>(
                name: "version_id",
                table: "History",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "ix_history_version_id",
                table: "History",
                column: "version_id");

            migrationBuilder.AddForeignKey(
                name: "fk_history_task_version_id",
                table: "History",
                column: "version_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
