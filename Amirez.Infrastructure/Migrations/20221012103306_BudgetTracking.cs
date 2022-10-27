using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class BudgetTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_folder_folder_folder_id",
                table: "folder");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("1a6fa4fc-7667-4164-abe9-4612c907430d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("86fb37ec-5269-4052-b8b9-712a50ee1476"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("8a8df9a6-afde-4b0f-be4a-c1bf3f79d911"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("c0c29a61-7ed3-48c5-bfe4-3ff88f594da5"));

            migrationBuilder.CreateTable(
                name: "budget_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "budget_track",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    subject = table.Column<string>(type: "TEXT", nullable: true),
                    ammount = table.Column<double>(type: "REAL", nullable: false),
                    category_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget_track", x => x.id);
                    table.ForeignKey(
                        name: "fk_budget_track_budget_category_category_id",
                        column: x => x.category_id,
                        principalTable: "budget_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("f21b38a9-6e3a-4f98-b08b-821f8a5ff3c0"), "97af90c0-898c-488e-a180-b61b8ce08b1f", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("f5d1e666-1bdd-4048-814c-d2b098e55c67"), "5c51fc3a-6dd0-4410-85c9-8744f6550c00", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("1b258f8d-a2a6-471c-b78e-9f60f73f7ff2"), "139515dc-f1eb-400e-924d-d82ab676c31d", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("06fbae86-7ef4-48a2-90da-d5414660e502"), "51c53034-7abd-495e-a579-beab6695c8ef", "Superviseur", null, 4 });

            migrationBuilder.CreateIndex(
                name: "ix_budget_track_category_id",
                table: "budget_track",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "fk_folder_folder_folder_id",
                table: "folder",
                column: "folder_id",
                principalTable: "folder",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal",
                column: "folder_id",
                principalTable: "folder",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_folder_folder_folder_id",
                table: "folder");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_folder_folder_id",
                table: "goal");

            migrationBuilder.DropTable(
                name: "budget_track");

            migrationBuilder.DropTable(
                name: "budget_category");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("06fbae86-7ef4-48a2-90da-d5414660e502"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("1b258f8d-a2a6-471c-b78e-9f60f73f7ff2"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("f21b38a9-6e3a-4f98-b08b-821f8a5ff3c0"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("f5d1e666-1bdd-4048-814c-d2b098e55c67"));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("1a6fa4fc-7667-4164-abe9-4612c907430d"), "ee81f48b-9f40-4345-82d5-8babea98d004", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("c0c29a61-7ed3-48c5-bfe4-3ff88f594da5"), "d5a69876-ddae-4521-8b77-9e7990a6070e", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("8a8df9a6-afde-4b0f-be4a-c1bf3f79d911"), "3db34325-bd67-4194-ab6a-fcd47fed211a", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("86fb37ec-5269-4052-b8b9-712a50ee1476"), "4675199c-c86c-4c70-aa7b-c48f14f32cb4", "Superviseur", null, 4 });

            migrationBuilder.AddForeignKey(
                name: "fk_folder_folder_folder_id",
                table: "folder",
                column: "folder_id",
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
    }
}
