using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlmacen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "detalle_inventario_id_fk",
                schema: "Almacen",
                table: "Salida");

            migrationBuilder.DropIndex(
                name: "IX_Salida_id_det_inventario",
                schema: "Almacen",
                table: "Salida");

            migrationBuilder.DropColumn(
                name: "motivo",
                schema: "Almacen",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "precio_compra",
                schema: "Almacen",
                table: "detalle_inventario");

            migrationBuilder.DropColumn(
                name: "precio_venta",
                schema: "Almacen",
                table: "detalle_inventario");

            migrationBuilder.RenameColumn(
                name: "id_det_inventario",
                schema: "Almacen",
                table: "Salida",
                newName: "id_insumo");

            migrationBuilder.AddColumn<int>(
                name: "id_Insumo",
                schema: "Almacen",
                table: "Entrada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "precio_compra",
                schema: "Almacen",
                table: "Entrada",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 13, 14, 27, 30, 983, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_id_Insumo",
                schema: "Almacen",
                table: "Entrada",
                column: "id_Insumo");

            migrationBuilder.AddForeignKey(
                name: "entrada_insumo_fk",
                schema: "Almacen",
                table: "Entrada",
                column: "id_Insumo",
                principalSchema: "Almacen",
                principalTable: "insumo",
                principalColumn: "id_insumo");

            migrationBuilder.AddForeignKey(
                name: "salida_insumo_fk",
                schema: "Almacen",
                table: "Salida",
                column: "id_inventario",
                principalSchema: "Almacen",
                principalTable: "insumo",
                principalColumn: "id_insumo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "entrada_insumo_fk",
                schema: "Almacen",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "salida_insumo_fk",
                schema: "Almacen",
                table: "Salida");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_id_Insumo",
                schema: "Almacen",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "id_Insumo",
                schema: "Almacen",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "precio_compra",
                schema: "Almacen",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "id_insumo",
                schema: "Almacen",
                table: "Salida",
                newName: "id_det_inventario");

            migrationBuilder.AddColumn<string>(
                name: "motivo",
                schema: "Almacen",
                table: "Entrada",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "precio_compra",
                schema: "Almacen",
                table: "detalle_inventario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "precio_venta",
                schema: "Almacen",
                table: "detalle_inventario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 10, 0, 29, 58, 98, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.CreateIndex(
                name: "IX_Salida_id_det_inventario",
                schema: "Almacen",
                table: "Salida",
                column: "id_det_inventario");

            migrationBuilder.AddForeignKey(
                name: "detalle_inventario_id_fk",
                schema: "Almacen",
                table: "Salida",
                column: "id_det_inventario",
                principalSchema: "Almacen",
                principalTable: "detalle_inventario",
                principalColumn: "id_det_inventario");
        }
    }
}
