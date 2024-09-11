using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class Empleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ventas");

            migrationBuilder.EnsureSchema(
                name: "Almacen");

            migrationBuilder.EnsureSchema(
                name: "Generico");

            migrationBuilder.EnsureSchema(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "cajas",
                schema: "Ventas",
                columns: table => new
                {
                    id_caja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_caja = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("caja_id_pk", x => x.id_caja);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                schema: "Almacen",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<bool>(type: "bit", maxLength: 100, nullable: false),
                    id_categoria_padre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categoria_id_pk", x => x.id_categoria);
                    table.ForeignKey(
                        name: "categorias_padre_fk",
                        column: x => x.id_categoria_padre,
                        principalSchema: "Almacen",
                        principalTable: "categorias",
                        principalColumn: "id_categoria");
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                schema: "Generico",
                columns: table => new
                {
                    id_img = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("imagenes_id_pk", x => x.id_img);
                });

            migrationBuilder.CreateTable(
                name: "mesas",
                schema: "Ventas",
                columns: table => new
                {
                    id_mesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    estado = table.Column<bool>(type: "bit", maxLength: 100, nullable: true),
                    estado_mesa_local = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mesa_id_pk", x => x.id_mesa);
                });

            migrationBuilder.CreateTable(
                name: "metodo_pago",
                schema: "Ventas",
                columns: table => new
                {
                    id_metodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    estado = table.Column<bool>(type: "bit", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("metodo_pago_id_pk", x => x.id_metodo);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "Usuarios",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    abreviacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_id_pk", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "tipo_comprobantes",
                schema: "Ventas",
                columns: table => new
                {
                    id_comprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipo_comprobante_id_pk", x => x.id_comprobante);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                schema: "Usuarios",
                columns: table => new
                {
                    id_tipo_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipo_documento_id_pk", x => x.id_tipo_documento);
                });

            migrationBuilder.CreateTable(
                name: "tipo_pedido",
                schema: "Ventas",
                columns: table => new
                {
                    id_tipo_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipo_pedido_id_pk", x => x.id_tipo_pedido);
                });

            migrationBuilder.CreateTable(
                name: "tipo_transaccion",
                schema: "Ventas",
                columns: table => new
                {
                    id_tipo_transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipo_transaccion_id_pk", x => x.id_tipo_transaccion);
                });

            migrationBuilder.CreateTable(
                name: "unidad_medicion",
                schema: "Generico",
                columns: table => new
                {
                    id_unidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    abreviacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("unidad_medicion_id_pk", x => x.id_unidad);
                });

            migrationBuilder.CreateTable(
                name: "apertura_cajas",
                schema: "Ventas",
                columns: table => new
                {
                    id_apertura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caja = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    monto_inicio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    hora_fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    monto_cierre = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    total_contado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sobrante = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    faltante = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    hora_fecha_cierre = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("apertura_caja_id_pk", x => x.id_apertura);
                    table.ForeignKey(
                        name: "caja_id_fk",
                        column: x => x.id_caja,
                        principalSchema: "Ventas",
                        principalTable: "cajas",
                        principalColumn: "id_caja");
                });

            migrationBuilder.CreateTable(
                name: "productos",
                schema: "Ventas",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    derivar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    id_img = table.Column<int>(type: "int", nullable: true),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("producto_id_pk", x => x.id_producto);
                    table.ForeignKey(
                        name: "img_id_fk",
                        column: x => x.id_img,
                        principalSchema: "Generico",
                        principalTable: "imagenes",
                        principalColumn: "id_img");
                    table.ForeignKey(
                        name: "producto_categoria_fk",
                        column: x => x.id_categoria,
                        principalSchema: "Almacen",
                        principalTable: "categorias",
                        principalColumn: "id_categoria");
                });

            migrationBuilder.CreateTable(
                name: "ambiente",
                schema: "Ventas",
                columns: table => new
                {
                    id_ambiente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_mesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ambiente_id_pk", x => x.id_ambiente);
                    table.ForeignKey(
                        name: "mesa_id_fk",
                        column: x => x.id_mesa,
                        principalSchema: "Ventas",
                        principalTable: "mesas",
                        principalColumn: "id_mesa");
                });

            migrationBuilder.CreateTable(
                name: "documentos",
                schema: "Ventas",
                columns: table => new
                {
                    id_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nro_documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_comprobante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("documento_id_pk", x => x.id_documento);
                    table.ForeignKey(
                        name: "comprobante_tipo_id_fk",
                        column: x => x.id_comprobante,
                        principalSchema: "Ventas",
                        principalTable: "tipo_comprobantes",
                        principalColumn: "id_comprobante");
                });

            migrationBuilder.CreateTable(
                name: "personas",
                schema: "Usuarios",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primer_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    segundo_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    apellido_paterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    apellido_materno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nro_Documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tipo_documento = table.Column<int>(type: "int", nullable: false),
                    tipo_persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    razon_social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("persona_id_pk", x => x.id_persona);
                    table.ForeignKey(
                        name: "tipo_documentos_id_fk",
                        column: x => x.tipo_documento,
                        principalSchema: "Usuarios",
                        principalTable: "tipo_documento",
                        principalColumn: "id_tipo_documento");
                });

            migrationBuilder.CreateTable(
                name: "voucher",
                schema: "Ventas",
                columns: table => new
                {
                    id_voucher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_emision = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cantidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    precio_unitario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    igv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    importe_total = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_tipo_transaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("voucher_id_pk", x => x.id_voucher);
                    table.ForeignKey(
                        name: "tipo_transaccion_id_fk",
                        column: x => x.id_tipo_transaccion,
                        principalSchema: "Ventas",
                        principalTable: "tipo_transaccion",
                        principalColumn: "id_tipo_transaccion");
                });

            migrationBuilder.CreateTable(
                name: "insumo",
                schema: "Almacen",
                columns: table => new
                {
                    id_insumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_unidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("insumo_id_pk", x => x.id_insumo);
                    table.ForeignKey(
                        name: "unidad_medida_id_fk",
                        column: x => x.id_unidad,
                        principalSchema: "Generico",
                        principalTable: "unidad_medicion",
                        principalColumn: "id_unidad");
                });

            migrationBuilder.CreateTable(
                name: "conteo_dinero",
                schema: "Ventas",
                columns: table => new
                {
                    id_conteo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_apertura = table.Column<int>(type: "int", nullable: false),
                    denominacion = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("conteo_dinero_id_pk", x => x.id_conteo);
                    table.ForeignKey(
                        name: "conteo_dinero_apertura_fk",
                        column: x => x.id_apertura,
                        principalSchema: "Ventas",
                        principalTable: "apertura_cajas",
                        principalColumn: "id_apertura");
                });

            migrationBuilder.CreateTable(
                name: "sucursal",
                schema: "Generico",
                columns: table => new
                {
                    id_sucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ambiente = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    id_documento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sucursal_id_pk", x => x.id_sucursal);
                    table.ForeignKey(
                        name: "ambientes_id_fk",
                        column: x => x.id_ambiente,
                        principalSchema: "Ventas",
                        principalTable: "ambiente",
                        principalColumn: "id_ambiente");
                    table.ForeignKey(
                        name: "documento_id_fk",
                        column: x => x.id_documento,
                        principalSchema: "Ventas",
                        principalTable: "documentos",
                        principalColumn: "id_documento");
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                schema: "Ventas",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cliente_id_pk", x => x.id_cliente);
                    table.ForeignKey(
                        name: "persona_id_fk",
                        column: x => x.id_persona,
                        principalSchema: "Usuarios",
                        principalTable: "personas",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                schema: "Almacen",
                columns: table => new
                {
                    id_proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    vende = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("proveedor_id_pk", x => x.id_proveedor);
                    table.ForeignKey(
                        name: "proveedor_id_fk",
                        column: x => x.id_persona,
                        principalSchema: "Usuarios",
                        principalTable: "personas",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    id_img = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cambiar_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    codigo_recuperacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usuario_id_pk", x => x.id_usuario);
                    table.ForeignKey(
                        name: "img_id_fk",
                        column: x => x.id_img,
                        principalSchema: "Generico",
                        principalTable: "imagenes",
                        principalColumn: "id_img");
                    table.ForeignKey(
                        name: "personas_usuarios_id_fk",
                        column: x => x.id_persona,
                        principalSchema: "Usuarios",
                        principalTable: "personas",
                        principalColumn: "id_persona");
                    table.ForeignKey(
                        name: "roles_id_fk",
                        column: x => x.id_rol,
                        principalSchema: "Usuarios",
                        principalTable: "roles",
                        principalColumn: "id_rol");
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                schema: "Ventas",
                columns: table => new
                {
                    id_empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("empleado_id_pk", x => x.id_empleado);
                    table.ForeignKey(
                        name: "empleado_persona_id_fk",
                        column: x => x.id_persona,
                        principalSchema: "Usuarios",
                        principalTable: "personas",
                        principalColumn: "id_persona");
                    table.ForeignKey(
                        name: "rol_id_fk",
                        column: x => x.id_rol,
                        principalSchema: "Usuarios",
                        principalTable: "roles",
                        principalColumn: "id_rol");
                    table.ForeignKey(
                        name: "sucursal_id_fk",
                        column: x => x.id_sucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal");
                });

            migrationBuilder.CreateTable(
                name: "inventario",
                schema: "Almacen",
                columns: table => new
                {
                    id_inventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventario_id_pk", x => x.id_inventario);
                    table.ForeignKey(
                        name: "sucursal_id_fk",
                        column: x => x.id_sucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal");
                });

            migrationBuilder.CreateTable(
                name: "producto_sucursal",
                schema: "Ventas",
                columns: table => new
                {
                    id_producto_sucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_unidad = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("producto_sucursal_id_pk", x => x.id_producto_sucursal);
                    table.ForeignKey(
                        name: "categorias_id_fk",
                        column: x => x.id_categoria,
                        principalSchema: "Almacen",
                        principalTable: "categorias",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "producto_id_fk",
                        column: x => x.id_producto,
                        principalSchema: "Ventas",
                        principalTable: "productos",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "sucursales_id_fk",
                        column: x => x.id_sucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal");
                    table.ForeignKey(
                        name: "unidad_medida_id_fk",
                        column: x => x.id_unidad,
                        principalSchema: "Generico",
                        principalTable: "unidad_medicion",
                        principalColumn: "id_unidad");
                });

            migrationBuilder.CreateTable(
                name: "sucursal_usuario",
                schema: "Ventas",
                columns: table => new
                {
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sucursal_id_usuario_pk", x => new { x.id_sucursal, x.id_usuario });
                    table.ForeignKey(
                        name: "sucursal_user_id_fk",
                        column: x => x.id_sucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal");
                    table.ForeignKey(
                        name: "usuario_id_fk",
                        column: x => x.id_usuario,
                        principalSchema: "Usuarios",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "pedidoLlevar",
                schema: "Ventas",
                columns: table => new
                {
                    id_pedido_llevar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_empleado = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    fecha_pedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    id_tipo_pedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pedido_llevar_id_pk", x => x.id_pedido_llevar);
                    table.ForeignKey(
                        name: "cliente_pedido_llevar_fk",
                        column: x => x.id_cliente,
                        principalSchema: "Ventas",
                        principalTable: "cliente",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "empleado_pedido_llevar_fk",
                        column: x => x.id_empleado,
                        principalSchema: "Ventas",
                        principalTable: "empleado",
                        principalColumn: "id_empleado");
                    table.ForeignKey(
                        name: "tipo_pedido_llevar_fk",
                        column: x => x.id_tipo_pedido,
                        principalSchema: "Ventas",
                        principalTable: "tipo_pedido",
                        principalColumn: "id_tipo_pedido");
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                schema: "Ventas",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_empleado = table.Column<int>(type: "int", nullable: false),
                    id_mesa = table.Column<int>(type: "int", nullable: false),
                    fecha_pedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    id_tipo_pedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pedido_id_pk", x => x.id_pedido);
                    table.ForeignKey(
                        name: "empleado_pedido_fk",
                        column: x => x.id_empleado,
                        principalSchema: "Ventas",
                        principalTable: "empleado",
                        principalColumn: "id_empleado");
                    table.ForeignKey(
                        name: "mesa_pedido_fk",
                        column: x => x.id_mesa,
                        principalSchema: "Ventas",
                        principalTable: "mesas",
                        principalColumn: "id_mesa");
                    table.ForeignKey(
                        name: "tipo_pedido_pedido_fk",
                        column: x => x.id_tipo_pedido,
                        principalSchema: "Ventas",
                        principalTable: "tipo_pedido",
                        principalColumn: "id_tipo_pedido");
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                schema: "Ventas",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_apertura = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_empleado = table.Column<int>(type: "int", nullable: false),
                    id_comprobante = table.Column<int>(type: "int", nullable: false),
                    id_voucher = table.Column<int>(type: "int", nullable: false),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", maxLength: 100, nullable: true),
                    id_metodo = table.Column<int>(type: "int", nullable: false),
                    nro_documento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nro_serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_tipo_pedido = table.Column<int>(type: "int", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime", nullable: true),
                    costo_base = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    igv = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    monto_total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    vuelto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    observacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("venta_id_pk", x => x.id_venta);
                    table.ForeignKey(
                        name: "apertura_caja_id_fk",
                        column: x => x.id_apertura,
                        principalSchema: "Ventas",
                        principalTable: "apertura_cajas",
                        principalColumn: "id_apertura");
                    table.ForeignKey(
                        name: "cliente_id_fk",
                        column: x => x.id_cliente,
                        principalSchema: "Ventas",
                        principalTable: "cliente",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "comprobante_id_fk",
                        column: x => x.id_comprobante,
                        principalSchema: "Ventas",
                        principalTable: "tipo_comprobantes",
                        principalColumn: "id_comprobante");
                    table.ForeignKey(
                        name: "empleado_id_fk",
                        column: x => x.id_empleado,
                        principalSchema: "Ventas",
                        principalTable: "empleado",
                        principalColumn: "id_empleado");
                    table.ForeignKey(
                        name: "metodo_id_fk",
                        column: x => x.id_metodo,
                        principalSchema: "Ventas",
                        principalTable: "metodo_pago",
                        principalColumn: "id_metodo");
                    table.ForeignKey(
                        name: "sucursales_ventas_id_fk",
                        column: x => x.id_sucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal");
                    table.ForeignKey(
                        name: "tipo_pedido_id_fk",
                        column: x => x.id_tipo_pedido,
                        principalSchema: "Ventas",
                        principalTable: "tipo_pedido",
                        principalColumn: "id_tipo_pedido");
                    table.ForeignKey(
                        name: "voucher_id_fk",
                        column: x => x.id_voucher,
                        principalSchema: "Ventas",
                        principalTable: "voucher",
                        principalColumn: "id_voucher");
                });

            migrationBuilder.CreateTable(
                name: "detalle_inventario",
                schema: "Almacen",
                columns: table => new
                {
                    id_det_inventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_inventario = table.Column<int>(type: "int", nullable: false),
                    id_insumo = table.Column<int>(type: "int", nullable: false),
                    stock_total = table.Column<int>(type: "int", nullable: false),
                    Id_Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_inventario_id_pk", x => x.id_det_inventario);
                    table.ForeignKey(
                        name: "det_insumo_id_fk",
                        column: x => x.id_insumo,
                        principalSchema: "Almacen",
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                    table.ForeignKey(
                        name: "inventario_id_fk",
                        column: x => x.id_inventario,
                        principalSchema: "Almacen",
                        principalTable: "inventario",
                        principalColumn: "id_inventario");
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                schema: "Almacen",
                columns: table => new
                {
                    id_entrada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_inventario = table.Column<int>(type: "int", nullable: false),
                    id_Insumo = table.Column<int>(type: "int", nullable: false),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_compra = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entrada_id_pk", x => x.id_entrada);
                    table.ForeignKey(
                        name: "entrada_insumo_fk",
                        column: x => x.id_Insumo,
                        principalSchema: "Almacen",
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                    table.ForeignKey(
                        name: "inventario_id_entrada_fk",
                        column: x => x.id_inventario,
                        principalSchema: "Almacen",
                        principalTable: "inventario",
                        principalColumn: "id_inventario");
                });

            migrationBuilder.CreateTable(
                name: "Salida",
                schema: "Almacen",
                columns: table => new
                {
                    id_salida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_inventario = table.Column<int>(type: "int", nullable: false),
                    id_insumo = table.Column<int>(type: "int", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    SucursalIdSucursal = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("salida_id_pk", x => x.id_salida);
                    table.ForeignKey(
                        name: "FK_Salida_sucursal_SucursalIdSucursal",
                        column: x => x.SucursalIdSucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "inventario_id_salida_fk",
                        column: x => x.id_inventario,
                        principalSchema: "Almacen",
                        principalTable: "inventario",
                        principalColumn: "id_inventario");
                    table.ForeignKey(
                        name: "salida_insumo_fk",
                        column: x => x.id_insumo,
                        principalSchema: "Almacen",
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                });

            migrationBuilder.CreateTable(
                name: "detalle_pedido_llevar",
                schema: "Ventas",
                columns: table => new
                {
                    id_detalle_pedido_llevar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_pedido_llevar = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_pedido_llevar_id_pk", x => x.id_detalle_pedido_llevar);
                    table.ForeignKey(
                        name: "pedido_llevar_detalle_fk",
                        column: x => x.id_pedido_llevar,
                        principalSchema: "Ventas",
                        principalTable: "pedidoLlevar",
                        principalColumn: "id_pedido_llevar");
                    table.ForeignKey(
                        name: "producto_detalle_pedido_llevar_fk",
                        column: x => x.id_producto,
                        principalSchema: "Ventas",
                        principalTable: "productos",
                        principalColumn: "id_producto");
                });

            migrationBuilder.CreateTable(
                name: "detalle_pedido",
                schema: "Ventas",
                columns: table => new
                {
                    id_detalle_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_pedido_id_pk", x => x.id_detalle_pedido);
                    table.ForeignKey(
                        name: "pedido_detalle_pedido_fk",
                        column: x => x.id_pedido,
                        principalSchema: "Ventas",
                        principalTable: "pedidos",
                        principalColumn: "id_pedido");
                    table.ForeignKey(
                        name: "producto_detalle_pedido_fk",
                        column: x => x.id_producto,
                        principalSchema: "Ventas",
                        principalTable: "productos",
                        principalColumn: "id_producto");
                });

            migrationBuilder.CreateTable(
                name: "detalle_venta",
                schema: "Ventas",
                columns: table => new
                {
                    id_detalle_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto_sucursal = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_venta_id_pk", x => x.id_detalle_venta);
                    table.ForeignKey(
                        name: "producto_detalle_venta_fk",
                        column: x => x.id_producto,
                        principalSchema: "Ventas",
                        principalTable: "productos",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "producto_sucursal_detalle_venta_fk",
                        column: x => x.id_producto_sucursal,
                        principalSchema: "Ventas",
                        principalTable: "producto_sucursal",
                        principalColumn: "id_producto_sucursal");
                    table.ForeignKey(
                        name: "venta_detalle_venta_fk",
                        column: x => x.id_venta,
                        principalSchema: "Ventas",
                        principalTable: "ventas",
                        principalColumn: "id_venta");
                });

            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "categorias",
                columns: new[] { "id_categoria", "estado", "id_categoria_padre", "nombre" },
                values: new object[,]
                {
                    { 1, true, null, "Hamburguesa" },
                    { 2, true, null, "Parrillas y Pollos" },
                    { 3, true, null, "Platos de Fondo" },
                    { 4, true, null, "Bebidas" },
                    { 5, true, null, "Complementos" }
                });

            migrationBuilder.InsertData(
                schema: "Generico",
                table: "imagenes",
                columns: new[] { "id_img", "nombre", "url" },
                values: new object[,]
                {
                    { 1, "Hamburguesa-clasica", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-clasica_ggudid.png" },
                    { 2, "Hamburguesa-queso-tocino", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-queso-tocino_li42kl.png" },
                    { 3, "Hamburguesa-senorial", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-senorial_qw9pko.png" },
                    { 4, "1-4-de-pollo-a-la-brasa", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258861/Pollo-a-la-brasa-1-4_kh0xna.png" },
                    { 5, "1-4-de-pollo-broaster", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258863/Pollo-broaster-1-4_bvqfwh.png" },
                    { 6, "Parrilla-de-pollo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo_mqiwcu.png" },
                    { 7, "Parrilla-de-pollo-al-ajo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo-al-ajo_zyzrtw.png" },
                    { 8, "Parrilla-de-pollo-dietetica", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo-dietetico_ym2r5n.png" },
                    { 9, "Parrilla-mixta", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258858/Parrilla-mixta_ehhq5k.png" },
                    { 10, "Brochetas-de-pollo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258870/Brochetas-de-pollo_jmqtvn.png" },
                    { 11, "Pollo-a-la-pizzarola", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pollo-a-la-pizzarola_orxsc5.png" },
                    { 12, "Bisteck-a-la-parrilla", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258870/Bisteck-a-la-parrilla_r9iclg.png" },
                    { 13, "Chorizo-a-la-parrilla", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Chorizo-a-la-parrilla_dgpnvt.png" },
                    { 14, "Chicharron-senorial", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chicharron-senorial_p50hre.png" },
                    { 15, "Lonjitas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258849/Lonjitas_xdukaq.png" },
                    { 16, "Chaufa-especial", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258877/Chaufa-especial_alryv8.png" },
                    { 17, "Chaufa-mixto", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chaufa-mixto_ysfysw.png" },
                    { 18, "Spaguetti-a-lo-alfredo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Spaguetti-a-lo-alfredo_pyobkl.png" },
                    { 19, "Cafe-pasado", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Cafe-pasado_fks93h.png" },
                    { 20, "Chocolate-con-panetón", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Chocolate-con-paneton_nbteel.png" },
                    { 21, "Leche-fresca", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258846/Leche-fresca_tpj7mm.png" },
                    { 22, "Milo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258852/Milo_yii8m1.png" },
                    { 23, "Cafe-con-leche", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Cafe-con-leche_rrxkzt.png" },
                    { 24, "Mates", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Mates_wcsite.png" },
                    { 25, "Gaseosa-3lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-3lts_el2kgx.png" },
                    { 26, "Gaseosa-2.25lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Gaseosa-de-2.25lts_r780yp.png" },
                    { 27, "Gaseosa-1.5lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Gaseosa-de-1.5lts_ajne1a.png" },
                    { 28, "Gaseosa-1lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-1lts_axqqpe.png" },
                    { 29, "Gaseosa-1-2lt", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-500ml_m2rgju.png" },
                    { 30, "Gaseosa-personal", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-personal_hnkmlf.png" },
                    { 31, "Gaseosa-piranita", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-piranita_jv3ord.png" },
                    { 32, "Refresco-de-maracuya-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258863/Refresco-de-maracuya-Jarra_aeakzt.png" },
                    { 33, "Chicha-morada-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chicha-morada-Jarra_xsjncx.png" },
                    { 34, "Limonada-Frozen-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258848/Limonada-frozen-Jarra_xftmfy.png" },
                    { 35, "Limonada-Americana-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258848/Limona-americana-Jarra_esgczd.png" },
                    { 36, "Caliente-de-pisco", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Caliente-de-pisco_sjalzc.png" },
                    { 37, "Caliente-de-vino", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258874/Caliente-de-vino_kwaift.png" },
                    { 38, "Caliente-de-ron", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Caliente-de-ron_pg2g1m.png" },
                    { 39, "Caliente-de-whisky", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Caliente-de-whisky_gpmkst.png" },
                    { 40, "Cerveza-en-lata", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Cerveza-en-lata_qozyqi.png" },
                    { 41, "Cerveza-negra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258877/Cerveza-negra_kk7eux.png" },
                    { 42, "Cerveza-de-trigo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Cerveza-de-trigo_yabm3n.png" },
                    { 43, "Vino-queirolo-vaso", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258867/Vino-queirolo-Vaso_kj8sbq.png" },
                    { 44, "Whisky-vaso", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258867/Wisky-Vaso_qnwn1m.png" },
                    { 45, "Pisco-Vargas-vaso", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pisco-vargas-Vaso_t8y3oz.png" },
                    { 46, "Mojito", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258854/Mojito_ubvhpc.png" },
                    { 47, "Machu-Picchu", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258849/Machu-picchu_sosb2h.png" },
                    { 48, "Daikiri", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Daikiri_scg5iq.png" },
                    { 49, "Pina-colada", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pina-colada_qoav6s.png" },
                    { 50, "Pisco-sour", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pisco-sour_xhrnzd.png" },
                    { 51, "Naranjita", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258856/Naranjita_jrm3qr.png" },
                    { 52, "Alitas-en-salsa-BBQ", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258869/Alitas-en-salsa-BBQ_itujfe.png" },
                    { 53, "Alitas-broaster", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258869/Alitas-broaster_e0wdiv.png" },
                    { 54, "Tequenos-especiales", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Tequenos-especiales_q4topa.png" },
                    { 55, "Durazno-en-almíbar", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Durazno-en-almibar_yfzewe.png" },
                    { 56, "Helado-02-bolas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Helado-02-bolas_n7g79i.png" },
                    { 57, "Helado-03-bolas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Helado-03-bolas_ct5qkk.png" },
                    { 58, "Gelatina", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Gelatina_lirwco.png" },
                    { 59, "Flan", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Flan_mygmdv.png" },
                    { 60, "Jugo-de-papaya", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-papaya_miqnbk.png" },
                    { 61, "Jugo-de-fresa-con-leche", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-fresa_abese7.png" },
                    { 62, "Jugo-de-platano", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-platano_yrsmee.png" },
                    { 63, "Jugo-surtido", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-surtido_fjl9jf.png" },
                    { 64, "Ensalada-de-frutas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Ensalada-de-frutas_jybwbc.png" },
                    { 65, "Milkshake-de-Oreo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-oreo_crwp9x.png" },
                    { 66, "Milkshake-de-durazno", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-durazno_p1ltvm.png" },
                    { 67, "Milkshake-de-fresa", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-fresa_btvt9f.png" },
                    { 68, "Salchipapa-clasica", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258864/Salchipapa-clasica_umbxrb.png" },
                    { 69, "Salchipapa-ayacuchana", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258864/Salchipapa-ayacuchana_vzk1h3.png" },
                    { 70, "Salchipiernita", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Salchipiernita_wxckli.png" },
                    { 71, "Mounstruo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258855/Mounstruo_bgqfgs.png" },
                    { 72, "Mounstrito", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258854/Mounstrito_vjfxho.png" }
                });

            migrationBuilder.InsertData(
                schema: "Ventas",
                table: "mesas",
                columns: new[] { "id_mesa", "estado", "estado_mesa_local", "nombre" },
                values: new object[,]
                {
                    { 1, true, null, "Mesa 1" },
                    { 2, true, null, "Mesa 2" },
                    { 3, true, null, "Mesa 3" },
                    { 4, true, null, "Mesa 4" },
                    { 5, true, null, "Mesa 5" },
                    { 6, true, null, "Mesa 6" },
                    { 7, true, null, "Mesa 7" },
                    { 8, true, null, "Mesa 8" },
                    { 9, true, null, "Mesa 9" }
                });

            migrationBuilder.InsertData(
                schema: "Ventas",
                table: "metodo_pago",
                columns: new[] { "id_metodo", "descripcion", "estado" },
                values: new object[,]
                {
                    { 1, "Efectivo", true },
                    { 2, "Tarjeta", true },
                    { 3, "Transferencia", true },
                    { 4, "Descuento", true },
                    { 5, "Otros", true }
                });

            migrationBuilder.InsertData(
                schema: "Usuarios",
                table: "roles",
                columns: new[] { "id_rol", "abreviacion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, null, "Activo", "Administrador" },
                    { 2, null, "Activo", "Desarrollador" },
                    { 3, null, "Activo", "Cajero" },
                    { 4, null, "Activo", "Mozo" },
                    { 5, null, "Activo", "Cliente" }
                });

            migrationBuilder.InsertData(
                schema: "Generico",
                table: "sucursal",
                columns: new[] { "id_sucursal", "direccion", "id_ambiente", "id_documento", "nombre" },
                values: new object[,]
                {
                    { 1, "", null, null, "Pio Pata" },
                    { 2, "", null, null, "Chilca" }
                });

            migrationBuilder.InsertData(
                schema: "Usuarios",
                table: "tipo_documento",
                columns: new[] { "id_tipo_documento", "nombre" },
                values: new object[,]
                {
                    { 1, "DNI" },
                    { 2, "RUC" },
                    { 3, "Pasaporte" },
                    { 4, "Carnet de Extranjería" }
                });

            migrationBuilder.InsertData(
                schema: "Ventas",
                table: "tipo_pedido",
                columns: new[] { "id_tipo_pedido", "descripcion" },
                values: new object[,]
                {
                    { 1, "Indoor" },
                    { 2, "PickUp" }
                });

            migrationBuilder.InsertData(
                schema: "Generico",
                table: "unidad_medicion",
                columns: new[] { "id_unidad", "abreviacion", "descripcion" },
                values: new object[,]
                {
                    { 1, "Balde", "Balde" },
                    { 2, "Lt", "Litro" },
                    { 3, "Und", "Unidad" },
                    { 4, "Kg", "Kilo" },
                    { 5, "Cto", "Ciento" },
                    { 6, "Rllo", "Rollo" },
                    { 7, "B-5Kg", "Bolsa 5 kg" },
                    { 8, "At", "Atado" },
                    { 9, "Bsa", "Bolsa" },
                    { 10, "Cja", "Caja" },
                    { 11, "B-20Kg", "Bolsa 20 kg" }
                });

            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "categorias",
                columns: new[] { "id_categoria", "estado", "id_categoria_padre", "nombre" },
                values: new object[,]
                {
                    { 6, true, 2, "Pollos" },
                    { 7, true, 2, "Parrillas" },
                    { 8, true, 2, "Otros" },
                    { 9, true, 3, "Comida Rápida" },
                    { 10, true, 4, "Bebidas Calientes" },
                    { 11, true, 4, "Bebidas Frías" },
                    { 12, true, 4, "Licores" },
                    { 13, true, 4, "Cócteles" },
                    { 14, true, 3, "Piqueos de la Casa" },
                    { 15, true, 5, "Postres" },
                    { 16, true, 5, "Jugos y Milkshakes" },
                    { 17, true, 1, "Hamburguesas" }
                });

            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "insumo",
                columns: new[] { "id_insumo", "id_unidad", "nombre", "url" },
                values: new object[,]
                {
                    { 1, 1, "Aceite x Balde", null },
                    { 2, 2, "Aceite x Litro", null },
                    { 3, 3, "Aceite Sésamo", null },
                    { 4, 4, "Aji", null },
                    { 5, 5, "Ajicero", null },
                    { 6, 3, "Arroz con leche", null },
                    { 7, 4, "Azucar Blanca", null },
                    { 8, 4, "Azucar Rubia", null },
                    { 9, 5, "Bolsa Basura", null },
                    { 10, 5, "Bolsa Cuarto Pollo", null },
                    { 11, 5, "Bolsa Ensalada", null },
                    { 12, 5, "Bolsa Medio Pollo", null },
                    { 13, 5, "Bolsa Pollo Entero", null },
                    { 14, 6, "Bolsa Rollo Pollo", null },
                    { 15, 3, "Café Sobre", null },
                    { 16, 3, "Caja ligas", null },
                    { 17, 7, "Carbón", null },
                    { 18, 4, "Cebolla", null },
                    { 19, 8, "Cebolla China", null },
                    { 20, 3, "Champiñon lata", null },
                    { 21, 9, "Chicha Morada", null },
                    { 22, 3, "Conserva Durazno", null },
                    { 23, 8, "Espinaca", null },
                    { 24, 4, "Fideo Spaguetti", null },
                    { 25, 3, "Fósforo", null },
                    { 26, 3, "Fresa", null },
                    { 27, 3, "Gas", null },
                    { 28, 8, "Hierba Buena", null },
                    { 29, 3, "Huevo", null },
                    { 30, 4, "Ketchup", null },
                    { 31, 2, "Leche", null },
                    { 32, 3, "Leche Evaporada", null },
                    { 33, 2, "Leche Fresca", null },
                    { 34, 3, "Lechuga", null },
                    { 35, 3, "Leña", null },
                    { 36, 4, "Limón", null },
                    { 37, 4, "Lonja", null },
                    { 38, 3, "Mates General", null },
                    { 39, 4, "Mayonesa", null },
                    { 40, 3, "Milo lata", null },
                    { 41, 10, "Mondadiente", null },
                    { 42, 4, "Mostaza", null },
                    { 43, 3, "Ostión", null },
                    { 44, 3, "Pan", null },
                    { 45, 3, "Panetón", null },
                    { 46, 11, "Papa", null },
                    { 47, 3, "Papaya", null },
                    { 48, 5, "Papel Manteca", null },
                    { 49, 3, "Pepino", null },
                    { 50, 3, "Pimenton", null },
                    { 51, 3, "Pisco", null },
                    { 52, 3, "Pollo", null },
                    { 53, 3, "Plátano", null },
                    { 54, 3, "Queso molde", null },
                    { 55, 3, "Queso Parmesano", null },
                    { 56, 9, "Refresco Maracuya", null },
                    { 57, 3, "Ron", null },
                    { 58, 3, "Salsa de Tomate", null },
                    { 59, 3, "Sillao", null },
                    { 60, 5, "Taper 6 u 8 Ensalada", null },
                    { 61, 5, "Taper Cuarto Pollo", null },
                    { 62, 5, "Taper Ensalada Entero", null },
                    { 63, 5, "Taper Medio Pollo", null },
                    { 64, 5, "Taper Pollo Entero", null },
                    { 65, 4, "Tomate", null },
                    { 66, 3, "Vaso Plástico Flan", null },
                    { 67, 3, "Vaso Plástico Gelatina", null },
                    { 68, 3, "Vaso Vidrio Flan", null },
                    { 69, 3, "Vaso Vidrio Gelatina", null },
                    { 70, 3, "Vinagre", null },
                    { 71, 4, "Vinagreta", null },
                    { 72, 3, "Vino", null },
                    { 73, 3, "Whiski", null },
                    { 74, 3, "Yuquitas", null },
                    { 75, 4, "Zanahoria", null }
                });

            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "inventario",
                columns: new[] { "id_inventario", "fecha_actualizacion", "id_sucursal" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 13, 32, 38, 888, DateTimeKind.Local).AddTicks(6563), 1 },
                    { 2, new DateTime(2024, 9, 8, 13, 32, 38, 888, DateTimeKind.Local).AddTicks(6565), 2 }
                });

            migrationBuilder.InsertData(
                schema: "Usuarios",
                table: "personas",
                columns: new[] { "id_persona", "apellido_materno", "apellido_paterno", "direccion", "email", "genero", "tipo_documento", "nro_Documento", "primer_nombre", "razon_social", "segundo_nombre", "telefono", "tipo_persona" },
                values: new object[] { 1, "", "Abregu", "", "admin@admin.com", "Masculino", 1, "", "Victor", "Señorial", "", "985851866", "Natural" });

            migrationBuilder.InsertData(
                schema: "Almacen",
                table: "detalle_inventario",
                columns: new[] { "id_det_inventario", "Id_Estado", "id_insumo", "id_inventario", "stock_total" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 12 },
                    { 2, 1, 2, 1, 12 },
                    { 3, 1, 3, 1, 12 },
                    { 4, 1, 4, 1, 12 },
                    { 5, 1, 5, 1, 12 },
                    { 6, 1, 6, 1, 12 },
                    { 7, 1, 7, 1, 12 },
                    { 8, 1, 8, 1, 12 },
                    { 9, 1, 9, 1, 12 },
                    { 10, 1, 10, 1, 12 },
                    { 11, 1, 11, 1, 12 },
                    { 12, 1, 12, 1, 12 },
                    { 13, 1, 13, 1, 12 },
                    { 14, 1, 14, 1, 12 },
                    { 15, 1, 15, 1, 12 },
                    { 16, 1, 16, 1, 12 },
                    { 17, 1, 17, 1, 12 },
                    { 18, 1, 18, 1, 12 },
                    { 19, 1, 19, 1, 12 },
                    { 20, 1, 20, 1, 12 },
                    { 21, 1, 21, 1, 12 },
                    { 22, 1, 22, 1, 12 },
                    { 23, 1, 23, 1, 12 },
                    { 24, 1, 24, 1, 12 },
                    { 25, 1, 25, 1, 12 },
                    { 26, 1, 26, 1, 12 },
                    { 27, 1, 27, 1, 12 },
                    { 28, 1, 28, 1, 12 },
                    { 29, 1, 29, 1, 12 },
                    { 30, 1, 30, 1, 12 },
                    { 31, 1, 31, 1, 12 },
                    { 32, 1, 32, 1, 12 },
                    { 33, 1, 33, 1, 12 },
                    { 34, 1, 34, 1, 12 },
                    { 35, 1, 35, 1, 12 },
                    { 36, 1, 36, 1, 12 },
                    { 37, 1, 37, 1, 12 },
                    { 38, 1, 38, 1, 12 },
                    { 39, 1, 39, 1, 12 },
                    { 40, 1, 40, 1, 12 },
                    { 41, 1, 41, 1, 12 },
                    { 42, 1, 42, 1, 12 },
                    { 43, 1, 43, 1, 12 },
                    { 44, 1, 44, 1, 12 },
                    { 45, 1, 45, 1, 12 },
                    { 46, 1, 46, 1, 12 },
                    { 47, 1, 47, 1, 12 },
                    { 48, 1, 48, 1, 12 },
                    { 49, 1, 49, 1, 12 },
                    { 50, 1, 50, 1, 12 },
                    { 51, 1, 51, 1, 12 },
                    { 52, 1, 52, 1, 12 },
                    { 53, 1, 53, 1, 12 },
                    { 54, 1, 54, 1, 12 },
                    { 55, 1, 55, 1, 12 },
                    { 56, 1, 56, 1, 12 },
                    { 57, 1, 57, 1, 12 },
                    { 58, 1, 58, 1, 12 },
                    { 59, 1, 59, 1, 12 },
                    { 60, 1, 60, 1, 12 },
                    { 61, 1, 61, 1, 12 },
                    { 62, 1, 62, 1, 12 },
                    { 63, 1, 63, 1, 12 },
                    { 64, 1, 64, 1, 12 },
                    { 65, 1, 65, 1, 12 },
                    { 66, 1, 66, 1, 12 },
                    { 67, 1, 67, 1, 12 },
                    { 68, 1, 68, 1, 12 },
                    { 69, 1, 69, 1, 12 },
                    { 70, 1, 70, 1, 12 },
                    { 71, 1, 71, 1, 12 },
                    { 72, 1, 72, 1, 12 },
                    { 73, 1, 73, 1, 12 },
                    { 74, 1, 74, 1, 12 },
                    { 75, 1, 75, 1, 12 }
                });

            migrationBuilder.InsertData(
                schema: "Ventas",
                table: "empleado",
                columns: new[] { "id_empleado", "estado", "id_persona", "id_rol", "id_sucursal" },
                values: new object[] { 1, true, 1, 1, 1 });

            migrationBuilder.InsertData(
                schema: "Ventas",
                table: "productos",
                columns: new[] { "id_producto", "derivar", "descripcion", "id_categoria", "id_img", "nombre", "precio" },
                values: new object[,]
                {
                    { 1, "Horno", "Hamburguesa clásica", 17, 1, "Hamburguesa clásica", 9.00m },
                    { 2, "Horno", "Hamburguesa queso tocino", 17, 2, "Hamburguesa queso tocino", 12.00m },
                    { 3, "Horno", "Hamburguesa señorial", 17, 3, "Hamburguesa señorial", 15.00m },
                    { 4, "Horno", "1/4 de pollo a la brasa", 6, 4, "1/4 de pollo a la brasa", 12.00m },
                    { 5, "Horno", "1/4 de pollo broaster", 6, 5, "1/4 de pollo broaster", 15.00m },
                    { 6, "Horno", "Parrilla de pollo", 7, 6, "Parrilla de pollo", 15.00m },
                    { 7, "Horno", "Parrilla de pollo al ajo", 7, 7, "Parrilla de pollo al ajo", 16.00m },
                    { 8, "Horno", "Parrilla de pollo dietética", 7, 8, "Parrilla de pollo dietética", 16.00m },
                    { 9, "Horno", "Parrilla mixta", 7, 9, "Parrilla mixta", 20.00m },
                    { 10, "Horno", "Brochetas de pollo", 8, 10, "Brochetas de pollo", 15.00m },
                    { 11, "Horno", "Pollo a la pizzarola", 8, 11, "Pollo a la pizzarola", 20.00m },
                    { 12, "Horno", "Bisteck a la parrilla", 8, 12, "Bisteck a la parrilla", 18.00m },
                    { 13, "Horno", "Chorizo a la parrilla", 8, 13, "Chorizo a la parrilla", 11.00m },
                    { 14, "Horno", "Chicharrón señorial", 9, 14, "Chicharrón señorial", 15.00m },
                    { 15, "Horno", "Lonjitas", 9, 15, "Lonjitas", 6.00m },
                    { 16, "Cocina", "Chaufa especial", 9, 16, "Chaufa especial", 10.00m },
                    { 17, "Cocina", "Chaufa mixto", 9, 17, "Chaufa mixto", 12.00m },
                    { 18, "Cocina", "Spaguetti a lo alfredo", 9, 18, "Spaguetti a lo alfredo", 14.00m },
                    { 19, "Cocina", "Café pasado", 10, 19, "Café pasado", 2.50m },
                    { 20, "Cocina", "Chocolate con panetón", 10, 20, "Chocolate con panetón", 5.00m },
                    { 21, "Cocina", "Leche fresca", 10, 21, "Leche fresca", 3.00m },
                    { 22, "Cocina", "Milo", 10, 22, "Milo", 3.00m },
                    { 23, "Cocina", "Café con leche", 10, 23, "Café con leche", 4.00m },
                    { 24, "Cocina", "Mates", 10, 24, "Mates", 2.00m },
                    { 25, "Cocina", "Gaseosa de 3lts", 11, 25, "Gaseosa de 3lts", 14.00m },
                    { 26, "Cocina", "Gaseosa de 2.25lts", 11, 26, "Gaseosa de 2.25lts", 11.00m },
                    { 27, "Cocina", "Gaseosa de 1.5lts", 11, 27, "Gaseosa de 1.5lts", 9.00m },
                    { 28, "Cocina", "Gaseosa de 1lts", 11, 28, "Gaseosa de 1lts", 7.00m },
                    { 29, "Cocina", "Gaseosa de 1/2lt", 11, 29, "Gaseosa de 1/2lt", 4.00m },
                    { 30, "Cocina", "Gaseosa personal", 11, 30, "Gaseosa personal", 2.50m },
                    { 31, "Cocina", "Gaseosa pirañita", 11, 31, "Gaseosa pirañita", 1.50m },
                    { 32, "Cocina", "Refresco de maracuya (Jarra)", 11, 32, "Refresco de maracuya (Jarra)", 8.00m },
                    { 33, "Cocina", "Chicha morada (Jarra)", 11, 33, "Chicha morada (Jarra)", 8.00m },
                    { 34, "Cocina", "Limonada Frozen (Jarra)", 11, 34, "Limonada Frozen (Jarra)", 12.00m },
                    { 35, "Cocina", "Limonada Americana (Jarra)", 11, 35, "Limonada Americana (Jarra)", 11.00m },
                    { 36, "Cocina", "Caliente de pisco", 12, 36, "Caliente de pisco", 30.00m },
                    { 37, "Cocina", "Caliente de vino", 12, 37, "Caliente de vino", 40.00m },
                    { 38, "Cocina", "Caliente de ron", 12, 38, "Caliente de ron", 35.00m },
                    { 39, "Cocina", "Caliente de whisky", 12, 39, "Caliente de whisky", 45.00m },
                    { 40, "Cocina", "Cerveza en lata", 12, 40, "Cerveza en lata", 6.00m },
                    { 41, "Cocina", "Cerveza negra", 12, 41, "Cerveza negra", 10.00m },
                    { 42, "Cocina", "Cerveza de trigo", 12, 42, "Cerveza de trigo", 10.00m },
                    { 43, "Cocina", "Vino queirolo (Vaso)", 12, 43, "Vino queirolo (Vaso)", 10.00m },
                    { 44, "Cocina", "Whisky (Vaso)", 12, 44, "Whisky (Vaso)", 10.00m },
                    { 45, "Cocina", "Pisco Vargas (Vaso)", 12, 45, "Pisco Vargas (Vaso)", 10.00m },
                    { 46, "Cocina", "Mojito", 13, 46, "Mojito", 15.90m },
                    { 47, "Cocina", "Machu Picchu", 13, 47, "Machu Picchu", 17.90m },
                    { 48, "Cocina", "Daikiri", 13, 48, "Daikiri", 15.90m },
                    { 49, "Cocina", "Piña colada", 13, 49, "Piña colada", 16.90m },
                    { 50, "Cocina", "Pisco sour", 13, 50, "Pisco sour", 15.90m },
                    { 51, "Cocina", "Naranjita", 13, 51, "Naranjita", 15.00m },
                    { 52, "Horno", "Alitas en salsa BBQ", 14, 52, "Alitas en salsa BBQ", 35.00m },
                    { 53, "Horno", "Alitas broaster", 14, 53, "Alitas broaster", 35.00m },
                    { 54, "Cocina", "Tequeños especiales", 14, 54, "Tequeños especiales", 20.00m },
                    { 55, "Cocina", "Durazno en almíbar", 15, 55, "Durazno en almíbar", 5.00m },
                    { 56, "Cocina", "Helado 02 bolas", 15, 56, "Helado 02 bolas", 4.00m },
                    { 57, "Cocina", "Helado 03 bolas", 15, 57, "Helado 03 bolas", 6.00m },
                    { 58, "Cocina", "Gelatina", 15, 58, "Gelatina", 3.00m },
                    { 59, "Cocina", "Flan", 15, 59, "Flan", 5.00m },
                    { 60, "Cocina", "Jugo de papaya", 16, 60, "Jugo de papaya", 5.00m },
                    { 61, "Cocina", "Jugo de fresa con leche", 16, 61, "Jugo de fresa con leche", 8.00m },
                    { 62, "Cocina", "Jugo de plátano", 16, 62, "Jugo de plátano", 5.00m },
                    { 63, "Cocina", "Jugo surtido", 16, 63, "Jugo surtido", 5.00m },
                    { 64, "Cocina", "Ensalada de frutas", 16, 64, "Ensalada de frutas", 7.00m },
                    { 65, "Cocina", "Milkshake de Oreo", 16, 65, "Milkshake de Oreo", 11.90m },
                    { 66, "Cocina", "Milkshake de durazno", 16, 66, "Milkshake de durazno", 11.90m },
                    { 67, "Cocina", "Milkshake de fresa", 16, 67, "Milkshake de fresa", 11.90m },
                    { 68, "Horno", "Salchipapa clásica", 9, 68, "Salchipapa clásica", 7.00m },
                    { 69, "Horno", "Salchipapa ayacuchana", 9, 69, "Salchipapa ayacuchana", 9.00m },
                    { 70, "Horno", "Salchipiernita", 9, 70, "Salchipiernita", 11.00m },
                    { 71, "Cocina", "Mounstruo", 9, 71, "Mounstruo", 18.00m },
                    { 72, "Cocina", "Mounstrito", 9, 72, "Mounstrito", 10.00m }
                });

            migrationBuilder.InsertData(
                schema: "Usuarios",
                table: "usuario",
                columns: new[] { "id_usuario", "cambiar_password", "codigo_recuperacion", "created_at", "email", "id_img", "id_persona", "id_rol", "password", "update_at", "user_name" },
                values: new object[] { 1, "", "", new DateTime(2024, 9, 8, 13, 32, 38, 911, DateTimeKind.Local).AddTicks(1475), "admin@admin.com", 1, 1, 1, "eQEguXgFEjSmgVeXYX+rexPeMAQ7AOMpdD8MPNqCe6s=", null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ambiente_id_mesa",
                schema: "Ventas",
                table: "ambiente",
                column: "id_mesa");

            migrationBuilder.CreateIndex(
                name: "IX_apertura_cajas_id_caja",
                schema: "Ventas",
                table: "apertura_cajas",
                column: "id_caja");

            migrationBuilder.CreateIndex(
                name: "categorias_nombre_uk",
                schema: "Almacen",
                table: "categorias",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categorias_id_categoria_padre",
                schema: "Almacen",
                table: "categorias",
                column: "id_categoria_padre");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_id_persona",
                schema: "Ventas",
                table: "cliente",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_conteo_dinero_id_apertura",
                schema: "Ventas",
                table: "conteo_dinero",
                column: "id_apertura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_inventario_id_insumo",
                schema: "Almacen",
                table: "detalle_inventario",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_inventario_id_inventario",
                schema: "Almacen",
                table: "detalle_inventario",
                column: "id_inventario");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_pedido_id_pedido",
                schema: "Ventas",
                table: "detalle_pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_pedido_id_producto",
                schema: "Ventas",
                table: "detalle_pedido",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_pedido_llevar_id_pedido_llevar",
                schema: "Ventas",
                table: "detalle_pedido_llevar",
                column: "id_pedido_llevar");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_pedido_llevar_id_producto",
                schema: "Ventas",
                table: "detalle_pedido_llevar",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_id_producto",
                schema: "Ventas",
                table: "detalle_venta",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_id_producto_sucursal",
                schema: "Ventas",
                table: "detalle_venta",
                column: "id_producto_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_id_venta",
                schema: "Ventas",
                table: "detalle_venta",
                column: "id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_documentos_id_comprobante",
                schema: "Ventas",
                table: "documentos",
                column: "id_comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_id_persona",
                schema: "Ventas",
                table: "empleado",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_id_rol",
                schema: "Ventas",
                table: "empleado",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_id_sucursal",
                schema: "Ventas",
                table: "empleado",
                column: "id_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_id_Insumo",
                schema: "Almacen",
                table: "Entrada",
                column: "id_Insumo");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_id_inventario",
                schema: "Almacen",
                table: "Entrada",
                column: "id_inventario");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_id_unidad",
                schema: "Almacen",
                table: "insumo",
                column: "id_unidad");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_id_sucursal",
                schema: "Almacen",
                table: "inventario",
                column: "id_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoLlevar_id_cliente",
                schema: "Ventas",
                table: "pedidoLlevar",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoLlevar_id_empleado",
                schema: "Ventas",
                table: "pedidoLlevar",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoLlevar_id_tipo_pedido",
                schema: "Ventas",
                table: "pedidoLlevar",
                column: "id_tipo_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_empleado",
                schema: "Ventas",
                table: "pedidos",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_mesa",
                schema: "Ventas",
                table: "pedidos",
                column: "id_mesa");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_tipo_pedido",
                schema: "Ventas",
                table: "pedidos",
                column: "id_tipo_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_personas_tipo_documento",
                schema: "Usuarios",
                table: "personas",
                column: "tipo_documento");

            migrationBuilder.CreateIndex(
                name: "personas_email_uk",
                schema: "Usuarios",
                table: "personas",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "personas_numero_documento_uk",
                schema: "Usuarios",
                table: "personas",
                column: "nro_Documento",
                unique: true,
                filter: "[nro_Documento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "personas_phone_uk",
                schema: "Usuarios",
                table: "personas",
                column: "telefono",
                unique: true,
                filter: "[telefono] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_producto_sucursal_id_categoria",
                schema: "Ventas",
                table: "producto_sucursal",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_producto_sucursal_id_producto",
                schema: "Ventas",
                table: "producto_sucursal",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_producto_sucursal_id_sucursal",
                schema: "Ventas",
                table: "producto_sucursal",
                column: "id_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_producto_sucursal_id_unidad",
                schema: "Ventas",
                table: "producto_sucursal",
                column: "id_unidad");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_categoria",
                schema: "Ventas",
                table: "productos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_img",
                schema: "Ventas",
                table: "productos",
                column: "id_img");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_id_persona",
                schema: "Almacen",
                table: "proveedor",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_id_insumo",
                schema: "Almacen",
                table: "Salida",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_id_inventario",
                schema: "Almacen",
                table: "Salida",
                column: "id_inventario");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_SucursalIdSucursal",
                schema: "Almacen",
                table: "Salida",
                column: "SucursalIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_sucursal_id_ambiente",
                schema: "Generico",
                table: "sucursal",
                column: "id_ambiente");

            migrationBuilder.CreateIndex(
                name: "IX_sucursal_id_documento",
                schema: "Generico",
                table: "sucursal",
                column: "id_documento");

            migrationBuilder.CreateIndex(
                name: "IX_sucursal_usuario_id_usuario",
                schema: "Ventas",
                table: "sucursal_usuario",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_img",
                schema: "Usuarios",
                table: "usuario",
                column: "id_img");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_persona",
                schema: "Usuarios",
                table: "usuario",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_rol",
                schema: "Usuarios",
                table: "usuario",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "usuario_user_email_uk",
                schema: "Usuarios",
                table: "usuario",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "usuario_user_name_uk",
                schema: "Usuarios",
                table: "usuario",
                column: "user_name",
                unique: true,
                filter: "[user_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_apertura",
                schema: "Ventas",
                table: "ventas",
                column: "id_apertura");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_cliente",
                schema: "Ventas",
                table: "ventas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_comprobante",
                schema: "Ventas",
                table: "ventas",
                column: "id_comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_empleado",
                schema: "Ventas",
                table: "ventas",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_metodo",
                schema: "Ventas",
                table: "ventas",
                column: "id_metodo");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_sucursal",
                schema: "Ventas",
                table: "ventas",
                column: "id_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_tipo_pedido",
                schema: "Ventas",
                table: "ventas",
                column: "id_tipo_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_voucher",
                schema: "Ventas",
                table: "ventas",
                column: "id_voucher");

            migrationBuilder.CreateIndex(
                name: "ventas_numero_documento_uk",
                schema: "Ventas",
                table: "ventas",
                column: "nro_documento",
                unique: true,
                filter: "[nro_documento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ventas_numero_serie_uk",
                schema: "Ventas",
                table: "ventas",
                column: "nro_serie",
                unique: true,
                filter: "[nro_serie] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_id_tipo_transaccion",
                schema: "Ventas",
                table: "voucher",
                column: "id_tipo_transaccion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conteo_dinero",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "detalle_inventario",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "detalle_pedido",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "detalle_pedido_llevar",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "detalle_venta",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "Entrada",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "proveedor",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "Salida",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "sucursal_usuario",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "pedidos",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "pedidoLlevar",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "producto_sucursal",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "ventas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "inventario",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "insumo",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "productos",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "apertura_cajas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "cliente",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "empleado",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "metodo_pago",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "tipo_pedido",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "voucher",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "unidad_medicion",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "imagenes",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "categorias",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "cajas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "personas",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "sucursal",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "tipo_transaccion",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "tipo_documento",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "ambiente",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "documentos",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "mesas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "tipo_comprobantes",
                schema: "Ventas");
        }
    }
}
