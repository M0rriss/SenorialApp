using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migraciones
{
    /// <inheritdoc />
    public partial class UpdateImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Generico",
                table: "imagenes",
                columns: new[] { "id_img", "nombre", "url" },
                values: new object[] { 1, "test", "https://th.bing.com/th/id/OIP.TpPLUJnbBx_WleAW68PhvQHaFF?rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 1,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 2,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 3,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 4,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 5,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 6,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 7,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 8,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 9,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 10,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 11,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 12,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 13,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 14,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 15,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 16,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 17,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 18,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 19,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 20,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 21,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 22,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 23,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 24,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 25,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 26,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 27,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 28,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 29,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 30,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 31,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 32,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 33,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 34,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 35,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 36,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 37,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 38,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 39,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 40,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 41,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 42,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 43,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 44,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 45,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 46,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 47,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 48,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 49,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 50,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 51,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 52,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 53,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 54,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 55,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 56,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 57,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 58,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 59,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 60,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 61,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 62,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 63,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 64,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 65,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 66,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 67,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 68,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 69,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 70,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 71,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 72,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 10, 0, 29, 58, 98, DateTimeKind.Local).AddTicks(1638));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 1,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 2,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 3,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 4,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 5,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 6,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 7,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 8,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 9,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 10,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 11,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 12,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 13,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 14,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 15,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 16,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 17,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 18,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 19,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 20,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 21,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 22,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 23,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 24,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 25,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 26,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 27,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 28,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 29,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 30,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 31,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 32,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 33,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 34,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 35,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 36,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 37,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 38,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 39,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 40,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 41,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 42,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 43,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 44,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 45,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 46,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 47,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 48,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 49,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 50,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 51,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 52,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 53,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 54,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 55,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 56,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 57,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 58,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 59,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 60,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 61,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 62,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 63,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 64,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 65,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 66,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 67,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 68,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 69,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 70,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 71,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 72,
                column: "id_img",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 7, 15, 17, 39, 28, 988, DateTimeKind.Local).AddTicks(5026));
        }
    }
}
