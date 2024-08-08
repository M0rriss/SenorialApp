using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.migraciones
{
    /// <inheritdoc />
    public partial class rmMenuDashB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_dash_menu",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "menu_dash",
                schema: "Usuarios");

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 14, 23, 19, 8, 555, DateTimeKind.Local).AddTicks(1662));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menu_dash",
                schema: "Usuarios",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_target = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    icono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    parent = table.Column<int>(type: "int", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_dash", x => x.id_menu);
                });

            migrationBuilder.CreateTable(
                name: "detalle_dash_menu",
                schema: "Usuarios",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_dash_menu", x => new { x.id_menu, x.id_rol });
                    table.ForeignKey(
                        name: "FK_detalle_dash_menu_menu_dash_id_menu",
                        column: x => x.id_menu,
                        principalSchema: "Usuarios",
                        principalTable: "menu_dash",
                        principalColumn: "id_menu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_dash_menu_roles_id_rol",
                        column: x => x.id_rol,
                        principalSchema: "Usuarios",
                        principalTable: "roles",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 14, 23, 13, 44, 86, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.CreateIndex(
                name: "IX_detalle_dash_menu_id_rol",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                column: "id_rol");
        }
    }
}
