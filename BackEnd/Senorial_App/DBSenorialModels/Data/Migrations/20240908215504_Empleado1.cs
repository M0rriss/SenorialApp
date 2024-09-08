using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class Empleado1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Ventas",
                table: "metodo_pago",
                keyColumn: "id_metodo",
                keyValue: 5);

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 9, 8, 16, 55, 3, 986, DateTimeKind.Local).AddTicks(4308));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 9, 8, 16, 55, 3, 986, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 9, 8, 16, 55, 3, 990, DateTimeKind.Local).AddTicks(7259));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 9, 8, 13, 32, 38, 888, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 9, 8, 13, 32, 38, 888, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.InsertData(
                schema: "Ventas",
                table: "metodo_pago",
                columns: new[] { "id_metodo", "descripcion", "estado" },
                values: new object[] { 5, "Otros", true });

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 9, 8, 13, 32, 38, 911, DateTimeKind.Local).AddTicks(1475));
        }
    }
}
