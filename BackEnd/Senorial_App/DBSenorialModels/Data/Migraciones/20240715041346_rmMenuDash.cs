using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.migraciones
{
    /// <inheritdoc />
    public partial class rmMenuDash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "menu_id_fk",
                schema: "Usuarios",
                table: "detalle_dash_menu");

            migrationBuilder.DropForeignKey(
                name: "rol_id_fk",
                schema: "Usuarios",
                table: "detalle_dash_menu");

            migrationBuilder.DropPrimaryKey(
                name: "dashboard_id_pk",
                schema: "Usuarios",
                table: "menu_dash");

            migrationBuilder.DropPrimaryKey(
                name: "detalle_dash_menu_id_pk",
                schema: "Usuarios",
                table: "detalle_dash_menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menu_dash",
                schema: "Usuarios",
                table: "menu_dash",
                column: "id_menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalle_dash_menu",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                columns: new[] { "id_menu", "id_rol" });

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 14, 23, 13, 44, 86, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_dash_menu_menu_dash_id_menu",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                column: "id_menu",
                principalSchema: "Usuarios",
                principalTable: "menu_dash",
                principalColumn: "id_menu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_dash_menu_roles_id_rol",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                column: "id_rol",
                principalSchema: "Usuarios",
                principalTable: "roles",
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_dash_menu_menu_dash_id_menu",
                schema: "Usuarios",
                table: "detalle_dash_menu");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_dash_menu_roles_id_rol",
                schema: "Usuarios",
                table: "detalle_dash_menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menu_dash",
                schema: "Usuarios",
                table: "menu_dash");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalle_dash_menu",
                schema: "Usuarios",
                table: "detalle_dash_menu");

            migrationBuilder.AddPrimaryKey(
                name: "dashboard_id_pk",
                schema: "Usuarios",
                table: "menu_dash",
                column: "id_menu");

            migrationBuilder.AddPrimaryKey(
                name: "detalle_dash_menu_id_pk",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                columns: new[] { "id_menu", "id_rol" });

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 14, 19, 3, 43, 439, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.AddForeignKey(
                name: "menu_id_fk",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                column: "id_menu",
                principalSchema: "Usuarios",
                principalTable: "menu_dash",
                principalColumn: "id_menu");

            migrationBuilder.AddForeignKey(
                name: "rol_id_fk",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                column: "id_rol",
                principalSchema: "Usuarios",
                principalTable: "roles",
                principalColumn: "id_rol");
        }
    }
}
