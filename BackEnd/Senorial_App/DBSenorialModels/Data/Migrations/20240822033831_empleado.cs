using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class empleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_empleado",
                schema: "Ventas",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 21, 22, 38, 29, 688, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 21, 22, 38, 29, 688, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 21, 22, 38, 29, 693, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_empleado",
                schema: "Ventas",
                table: "pedidos",
                column: "id_empleado");

            migrationBuilder.AddForeignKey(
                name: "empleado_pedido_fk",
                schema: "Ventas",
                table: "pedidos",
                column: "id_empleado",
                principalSchema: "Ventas",
                principalTable: "empleado",
                principalColumn: "id_empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "empleado_pedido_fk",
                schema: "Ventas",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_id_empleado",
                schema: "Ventas",
                table: "pedidos");

            migrationBuilder.DropColumn(
                name: "id_empleado",
                schema: "Ventas",
                table: "pedidos");

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
    }
}
