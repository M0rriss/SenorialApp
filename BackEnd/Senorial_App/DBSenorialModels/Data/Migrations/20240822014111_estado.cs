using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class estado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo_pedido",
                schema: "Ventas",
                table: "pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "estado",
                schema: "Ventas",
                table: "pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "id_tipo_pedido",
                schema: "Ventas",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoMesaLocal",
                schema: "Ventas",
                table: "mesas",
                type: "int",
                nullable: true);

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
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 1,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 2,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 3,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 4,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 5,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 6,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 7,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 8,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "mesas",
                keyColumn: "id_mesa",
                keyValue: 9,
                column: "EstadoMesaLocal",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 21, 20, 41, 9, 500, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_tipo_pedido",
                schema: "Ventas",
                table: "pedidos",
                column: "id_tipo_pedido");

            migrationBuilder.AddForeignKey(
                name: "tipo_pedido_pedido_fk",
                schema: "Ventas",
                table: "pedidos",
                column: "id_tipo_pedido",
                principalSchema: "Ventas",
                principalTable: "tipo_pedido",
                principalColumn: "id_tipo_pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tipo_pedido_pedido_fk",
                schema: "Ventas",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_id_tipo_pedido",
                schema: "Ventas",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "id_tipo_pedido",
                schema: "Ventas",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "EstadoMesaLocal",
                schema: "Ventas",
                table: "mesas");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                schema: "Ventas",
                table: "pedidos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo_pedido",
                schema: "Ventas",
                table: "pedidos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 20, 15, 12, 55, 141, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 20, 15, 12, 55, 141, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 20, 15, 12, 55, 149, DateTimeKind.Local).AddTicks(379));
        }
    }
}
