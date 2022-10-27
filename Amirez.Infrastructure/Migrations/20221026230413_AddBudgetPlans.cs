using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class AddBudgetPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("72021f0c-6978-4c4b-a664-27b7dc4a1b79"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("729f76a4-b502-458f-aaec-5eaf5100b66a"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("8268ed07-8493-44bb-9431-5e00da8c3fce"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("ab3f123f-b8a4-462b-a186-08302f08a248"));

            migrationBuilder.CreateTable(
                name: "budget_plan",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    repeat = table.Column<bool>(type: "INTEGER", nullable: false),
                    subject = table.Column<string>(type: "TEXT", nullable: true),
                    ammount = table.Column<double>(type: "REAL", nullable: false),
                    category_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget_plan", x => x.id);
                    table.ForeignKey(
                        name: "fk_budget_plan_budget_category_category_id",
                        column: x => x.category_id,
                        principalTable: "budget_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_budget_plan_category_id",
                table: "budget_plan",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budget_plan");

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

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("ab3f123f-b8a4-462b-a186-08302f08a248"), "491c2228-266c-40d7-8dc7-c8b898fd7841", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("72021f0c-6978-4c4b-a664-27b7dc4a1b79"), "9f244cca-74f0-4e97-8ae8-fdc78e338ce9", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("8268ed07-8493-44bb-9431-5e00da8c3fce"), "31a2669e-a372-4434-b735-34bad5951991", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("729f76a4-b502-458f-aaec-5eaf5100b66a"), "2f1181c4-a8d5-4307-82bb-3a94886085db", "Superviseur", null, 4 });
        }
    }
}
