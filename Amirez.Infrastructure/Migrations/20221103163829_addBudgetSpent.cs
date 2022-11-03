using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class addBudgetSpent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("1a5668cf-dffb-41e7-b4bb-814c24b462af"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("2098ea56-437f-4855-bbd0-cdcee38fe47d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("b4ad3f50-3545-426f-bd1f-4afb3534d51b"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("e1561260-7ac3-49f7-a5f1-08ad91bd51a4"));

            migrationBuilder.CreateTable(
                name: "budget_spent",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    subject = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    parent_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget_spent", x => x.id);
                    table.ForeignKey(
                        name: "fk_budget_spent_budget_track_parent_id",
                        column: x => x.parent_id,
                        principalTable: "budget_track",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("ee69dc90-1311-4bb1-b405-22cc6d7de683"), "e4192229-31f5-4b5b-be8c-071b493cdc01", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("a94159c7-5259-483d-9a7e-54fb08f3de0a"), "0d0174a9-c95a-4e9d-9363-1b98f03608fd", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("a1613e9c-ecb5-44fe-9431-4b0bb600d02c"), "9f0bb348-45d2-4dad-ad2e-e9ed62407fab", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("b24de341-855f-40e2-967d-300dc32a4cdb"), "9286414c-21b9-4f5c-833a-a2b2067c1cbb", "Superviseur", null, 4 });

            migrationBuilder.CreateIndex(
                name: "ix_budget_spent_parent_id",
                table: "budget_spent",
                column: "parent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budget_spent");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("a1613e9c-ecb5-44fe-9431-4b0bb600d02c"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("a94159c7-5259-483d-9a7e-54fb08f3de0a"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("b24de341-855f-40e2-967d-300dc32a4cdb"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("ee69dc90-1311-4bb1-b405-22cc6d7de683"));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("b4ad3f50-3545-426f-bd1f-4afb3534d51b"), "7283e8ec-e671-4816-8094-1422e7cc7b4d", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("1a5668cf-dffb-41e7-b4bb-814c24b462af"), "3f90a46b-d43c-4563-8c0f-01b53f6751b6", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("2098ea56-437f-4855-bbd0-cdcee38fe47d"), "21f6004a-0d61-4729-a159-c7f9bbc06711", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("e1561260-7ac3-49f7-a5f1-08ad91bd51a4"), "7bd3bcb2-28f9-48f7-9d66-614132133bfc", "Superviseur", null, 4 });
        }
    }
}
