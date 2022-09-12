using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class updatetaskdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("0f580311-e401-431b-ae56-3cbed1fa9927"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("239f3f6d-0149-4c58-892f-81e1b3b04782"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("8dfe6318-2d0f-4c82-b3d3-7fcdd26d5c2e"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("cca49e2b-8d9f-4b49-8063-2a491eeb6d42"));

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
                name: "fk_history_task_task_data_model_id",
                table: "History",
                column: "parent_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History");

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

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("8dfe6318-2d0f-4c82-b3d3-7fcdd26d5c2e"), "6cf38adb-6052-4df9-80e8-7fae6491e764", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("239f3f6d-0149-4c58-892f-81e1b3b04782"), "63452545-599d-4cc1-baad-e4d689128bd0", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("0f580311-e401-431b-ae56-3cbed1fa9927"), "2eacf9e2-ecf8-48ec-9ba5-0a1fdaf121fc", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("cca49e2b-8d9f-4b49-8063-2a491eeb6d42"), "622e8ee5-65fe-4a04-aa7d-72b8e747e1da", "Superviseur", null, 4 });

            migrationBuilder.AddForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History",
                column: "parent_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
