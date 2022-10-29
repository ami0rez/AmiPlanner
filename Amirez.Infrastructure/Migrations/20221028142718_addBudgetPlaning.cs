using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class addBudgetPlaning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("20c19850-249b-46b3-905d-fce679872d24"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("2d691414-3524-4909-9935-5275c0888624"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("3dbdf2c4-dd43-439b-a92c-eecf33e6e05d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("6b71f421-490c-4a31-8111-733a87d138ec"));

            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "budget_track",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "budget_plan",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("846f81eb-810f-4f88-9b46-3bb38b51a106"), "b98a0d7b-505f-46e3-89a4-b13423c4dbae", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("a1b52537-51e8-4ed4-ac8c-7a7d14166956"), "2f8f2aff-8e45-444e-95ad-3105ed30b4c7", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("39b10f54-d761-45f0-9d61-b82519392c61"), "aca5f1bf-f05e-43d0-aec2-3aeb60573bf4", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("ccf9ab92-6dbb-431c-b99f-e7769a99d727"), "e7f3739c-924f-48be-b104-115a8084eb3f", "Superviseur", null, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("39b10f54-d761-45f0-9d61-b82519392c61"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("846f81eb-810f-4f88-9b46-3bb38b51a106"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("a1b52537-51e8-4ed4-ac8c-7a7d14166956"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("ccf9ab92-6dbb-431c-b99f-e7769a99d727"));

            migrationBuilder.DropColumn(
                name: "paid",
                table: "budget_track");

            migrationBuilder.DropColumn(
                name: "paid",
                table: "budget_plan");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("20c19850-249b-46b3-905d-fce679872d24"), "12639d75-b88e-45ed-a7e3-511ec2af3c7e", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("3dbdf2c4-dd43-439b-a92c-eecf33e6e05d"), "e046aa4f-7614-404d-852d-6d1413d84d17", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("6b71f421-490c-4a31-8111-733a87d138ec"), "9c56b161-42b7-4c4e-82bb-343c0a8f7b55", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("2d691414-3524-4909-9935-5275c0888624"), "387f2977-195b-41c4-b703-6874e2caa1a9", "Superviseur", null, 4 });
        }
    }
}
