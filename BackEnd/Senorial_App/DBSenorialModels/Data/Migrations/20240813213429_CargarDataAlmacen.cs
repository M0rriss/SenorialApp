using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class CargarDataAlmacen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "inventario",
                columns: new[] { "id_inventario", "fecha_actualizacion", "id_sucursal" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 13, 16, 34, 27, 561, DateTimeKind.Local).AddTicks(9294), 1 },
                    { 2, new DateTime(2024, 8, 13, 16, 34, 27, 561, DateTimeKind.Local).AddTicks(9296), 2 }
                });

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 13, 16, 34, 27, 565, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "detalle_inventario",
                columns: new[] { "id_det_inventario", "id_insumo", "id_inventario", "stock_total" },
                values: new object[,]
                {
                    { 1, 1, 1, 12 },
                    { 2, 2, 1, 12 },
                    { 3, 3, 1, 12 },
                    { 4, 4, 1, 12 },
                    { 5, 5, 1, 12 },
                    { 6, 6, 1, 12 },
                    { 7, 7, 1, 12 },
                    { 8, 8, 1, 12 },
                    { 9, 9, 1, 12 },
                    { 10, 10, 1, 12 },
                    { 11, 11, 1, 12 },
                    { 12, 12, 1, 12 },
                    { 13, 13, 1, 12 },
                    { 14, 14, 1, 12 },
                    { 15, 15, 1, 12 },
                    { 16, 16, 1, 12 },
                    { 17, 17, 1, 12 },
                    { 18, 18, 1, 12 },
                    { 19, 19, 1, 12 },
                    { 20, 20, 1, 12 },
                    { 21, 21, 1, 12 },
                    { 22, 22, 1, 12 },
                    { 23, 23, 1, 12 },
                    { 24, 24, 1, 12 },
                    { 25, 25, 1, 12 },
                    { 26, 26, 1, 12 },
                    { 27, 27, 1, 12 },
                    { 28, 28, 1, 12 },
                    { 29, 29, 1, 12 },
                    { 30, 30, 1, 12 },
                    { 31, 31, 1, 12 },
                    { 32, 32, 1, 12 },
                    { 33, 33, 1, 12 },
                    { 34, 34, 1, 12 },
                    { 35, 35, 1, 12 },
                    { 36, 36, 1, 12 },
                    { 37, 37, 1, 12 },
                    { 38, 38, 1, 12 },
                    { 39, 39, 1, 12 },
                    { 40, 40, 1, 12 },
                    { 41, 41, 1, 12 },
                    { 42, 42, 1, 12 },
                    { 43, 43, 1, 12 },
                    { 44, 44, 1, 12 },
                    { 45, 45, 1, 12 },
                    { 46, 46, 1, 12 },
                    { 47, 47, 1, 12 },
                    { 48, 48, 1, 12 },
                    { 49, 49, 1, 12 },
                    { 50, 50, 1, 12 },
                    { 51, 51, 1, 12 },
                    { 52, 52, 1, 12 },
                    { 53, 53, 1, 12 },
                    { 54, 54, 1, 12 },
                    { 55, 55, 1, 12 },
                    { 56, 56, 1, 12 },
                    { 57, 57, 1, 12 },
                    { 58, 58, 1, 12 },
                    { 59, 59, 1, 12 },
                    { 60, 60, 1, 12 },
                    { 61, 61, 1, 12 },
                    { 62, 62, 1, 12 },
                    { 63, 63, 1, 12 },
                    { 64, 64, 1, 12 },
                    { 65, 65, 1, 12 },
                    { 66, 66, 1, 12 },
                    { 67, 67, 1, 12 },
                    { 68, 68, 1, 12 },
                    { 69, 69, 1, 12 },
                    { 70, 70, 1, 12 },
                    { 71, 71, 1, 12 },
                    { 72, 72, 1, 12 },
                    { 73, 73, 1, 12 },
                    { 74, 74, 1, 12 },
                    { 75, 75, 1, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "detalle_inventario",
                keyColumn: "id_det_inventario",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 13, 14, 27, 30, 983, DateTimeKind.Local).AddTicks(1546));
        }
    }
}
