using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class addPaymentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "payment_date",
                table: "budget_track",
                type: "TEXT",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "payment_date",
                table: "budget_track");

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
    }
}
