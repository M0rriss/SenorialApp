using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class estado2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoMesaLocal",
                schema: "Ventas",
                table: "mesas",
                newName: "estado_mesa_local");

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 21, 20, 49, 32, 838, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 21, 20, 49, 32, 838, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 21, 20, 49, 32, 842, DateTimeKind.Local).AddTicks(3577));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado_mesa_local",
                schema: "Ventas",
                table: "mesas",
                newName: "EstadoMesaLocal");

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 21, 20, 41, 9, 496, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 21, 20, 41, 9, 496, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 21, 20, 41, 9, 500, DateTimeKind.Local).AddTicks(2977));
        }
    }
}
