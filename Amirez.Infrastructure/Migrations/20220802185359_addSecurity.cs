using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amirez.Infrastructure.Migrations
{
    public partial class addSecurity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_history_task_parent_id",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History");

            migrationBuilder.DropIndex(
                name: "ix_history_task_data_model_id",
                table: "History");

            migrationBuilder.DropColumn(
                name: "task_data_model_id",
                table: "History");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    role_type = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    claim_type = table.Column<string>(type: "TEXT", nullable: true),
                    claim_value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claim_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nom = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    prenom = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    bloque = table.Column<bool>(type: "INTEGER", nullable: false),
                    role_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    user_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    password_hash = table.Column<string>(type: "TEXT", nullable: true),
                    security_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    access_failed_count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur", x => x.id);
                    table.ForeignKey(
                        name: "fk_utilisateur_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    claim_type = table.Column<string>(type: "TEXT", nullable: true),
                    claim_value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_utilisateur_claim_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "TEXT", nullable: false),
                    provider_key = table.Column<string>(type: "TEXT", nullable: false),
                    provider_display_name = table.Column<string>(type: "TEXT", nullable: true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_utilisateur_login_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur_role",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    role_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_utilisateur_role_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_utilisateur_role_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur_token",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    login_provider = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_utilisateur_token_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_claim_role_id",
                table: "role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "utilisateur",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_utilisateur_role_id",
                table: "utilisateur",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "utilisateur",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_utilisateur_claim_user_id",
                table: "utilisateur_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_utilisateur_login_user_id",
                table: "utilisateur_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_utilisateur_role_role_id",
                table: "utilisateur_role",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History",
                column: "parent_id",
                principalTable: "task",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_history_task_task_data_model_id",
                table: "History");

            migrationBuilder.DropTable(
                name: "role_claim");

            migrationBuilder.DropTable(
                name: "utilisateur_claim");

            migrationBuilder.DropTable(
                name: "utilisateur_login");

            migrationBuilder.DropTable(
                name: "utilisateur_role");

            migrationBuilder.DropTable(
                name: "utilisateur_token");

            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.AddColumn<Guid>(
                name: "task_data_model_id",
                table: "History",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_history_task_data_model_id",
                table: "History",
                column: "task_data_model_id");

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
        }
    }
}
