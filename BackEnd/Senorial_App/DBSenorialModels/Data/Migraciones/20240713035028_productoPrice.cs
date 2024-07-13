using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migraciones
{
    /// <inheritdoc />
    public partial class productoPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "precio",
                schema: "Ventas",
                table: "productos",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 1,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 2,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 3,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 4,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 5,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 6,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 7,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 8,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 9,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 10,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 11,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 12,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 13,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 14,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 15,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 16,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 17,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 18,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 19,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 20,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 21,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 22,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 23,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 24,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 25,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 26,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 27,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 28,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 29,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 30,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 31,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 32,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 33,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 34,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 35,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 36,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 37,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 38,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 39,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 40,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 41,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 42,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 43,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 44,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 45,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 46,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 47,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 48,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 49,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 50,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 51,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 52,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 53,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 54,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 55,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 56,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 57,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 58,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 59,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 60,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 61,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 62,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 63,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 64,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 65,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 66,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 67,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 68,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 69,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 70,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 71,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 72,
                column: "precio",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 12, 22, 50, 27, 389, DateTimeKind.Local).AddTicks(6783));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "precio",
                schema: "Ventas",
                table: "productos");

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 12, 22, 32, 1, 453, DateTimeKind.Local).AddTicks(3855));
        }
    }
}
