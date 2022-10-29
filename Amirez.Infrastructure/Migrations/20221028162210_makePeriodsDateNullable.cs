using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class makePeriodsDateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_date",
                table: "budget_period",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_date",
                table: "budget_period",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
