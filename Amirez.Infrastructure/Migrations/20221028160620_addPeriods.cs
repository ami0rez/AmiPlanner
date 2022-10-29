using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class addPeriods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("13568c39-7795-47d1-a5b7-4e5e6f6c79ec"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("2e621ce1-4cee-47cb-932e-10327e7e7a94"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("423773e2-ee1f-44d3-8df0-b7dcbbba8025"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("63da6adc-ad11-4710-9be0-845e685c3d81"));

            migrationBuilder.CreateTable(
                name: "budget_period",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    closed = table.Column<bool>(type: "INTEGER", nullable: false),
                    closed_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budget_period", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("fb8071a3-d9e9-4840-a238-dd555df5cdcc"), "d5e73d7c-4709-4e16-9819-c7151fe66a48", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("437ec833-24aa-4cef-aabb-ffa6ab8a8b74"), "7d9ef546-8e1a-40f1-92d6-365083b452d5", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("5f205bde-f1a9-4fab-aece-b7626e45b4d5"), "93c5518d-3d5e-4cd3-864e-162223ca1302", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("4cb6d4c2-e5c4-4f45-874f-5e8495ac689d"), "51b17d2f-0d34-41ab-81aa-294d102ed31b", "Superviseur", null, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budget_period");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("437ec833-24aa-4cef-aabb-ffa6ab8a8b74"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("4cb6d4c2-e5c4-4f45-874f-5e8495ac689d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("5f205bde-f1a9-4fab-aece-b7626e45b4d5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "id",
                keyValue: new Guid("fb8071a3-d9e9-4840-a238-dd555df5cdcc"));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("63da6adc-ad11-4710-9be0-845e685c3d81"), "ff890225-0bd1-4377-a852-51725811d017", "Administrateur", null, 1 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("423773e2-ee1f-44d3-8df0-b7dcbbba8025"), "03c9d97e-64b7-48f0-8ab3-4f311b9620cd", "Cb", null, 2 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("13568c39-7795-47d1-a5b7-4e5e6f6c79ec"), "e314fbd8-9560-4f7f-92b4-8f63f06a5a27", "Ruo", null, 3 });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "role_type" },
                values: new object[] { new Guid("2e621ce1-4cee-47cb-932e-10327e7e7a94"), "b76bd725-f18a-4ed8-bf3c-3f816047c9a8", "Superviseur", null, 4 });
        }
    }
}
