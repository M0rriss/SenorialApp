using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdImg",
                schema: "Usuarios",
                table: "usuario",
                newName: "id_img");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_IdImg",
                schema: "Usuarios",
                table: "usuario",
                newName: "IX_usuario_id_img");

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 14, 17, 17, 5, 586, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 14, 17, 17, 5, 586, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                columns: new[] { "created_at", "id_img" },
                values: new object[] { new DateTime(2024, 8, 14, 17, 17, 5, 590, DateTimeKind.Local).AddTicks(251), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_img",
                schema: "Usuarios",
                table: "usuario",
                newName: "IdImg");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_id_img",
                schema: "Usuarios",
                table: "usuario",
                newName: "IX_usuario_IdImg");

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 13, 16, 34, 27, 561, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 13, 16, 34, 27, 561, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                columns: new[] { "created_at", "IdImg" },
                values: new object[] { new DateTime(2024, 8, 13, 16, 34, 27, 565, DateTimeKind.Local).AddTicks(5051), null });
        }
    }
}
