using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class AddRepeatToBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "repeat",
                table: "budget_track",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "repeat",
                table: "budget_track");

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
        }
    }
}
