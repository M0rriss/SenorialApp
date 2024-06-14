using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBSenorialModels.Data.Migraciones
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ventas");

            migrationBuilder.EnsureSchema(
                name: "Almacen");

            migrationBuilder.EnsureSchema(
                name: "Usuarios");

            migrationBuilder.EnsureSchema(
                name: "Produccion");

            migrationBuilder.EnsureSchema(
                name: "Generico");

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
                name: "estado",
                schema: "Generico",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    abreviacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_estado_padre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("estado_id_pk", x => x.id_estado);
                    table.ForeignKey(
                        name: "estado_padre_fk",
                        column: x => x.id_estado_padre,
                        principalSchema: "Generico",
                        principalTable: "estado",
                        principalColumn: "id_estado");
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
                name: "menu_dash",
                schema: "Usuarios",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    icono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    data_target = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dashboard_id_pk", x => x.id_menu);
                });

            migrationBuilder.CreateTable(
                name: "mesas",
                schema: "Ventas",
                columns: table => new
                {
                    id_mesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("metodo_pago_id_pk", x => x.id_metodo);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                schema: "Usuarios",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nro_Documento = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tipo_documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipo_persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("persona_id_pk", x => x.id_persona);
                });

            migrationBuilder.CreateTable(
                name: "produccion",
                schema: "Produccion",
                columns: table => new
                {
                    id_produccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad_total = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("produccion_id_pk", x => x.id_produccion);
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
                name: "ubigeo",
                schema: "Generico",
                columns: table => new
                {
                    id_ubigeo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    distrito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ubigeo_id_pk", x => x.id_ubigeo);
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
                name: "roles",
                schema: "Usuarios",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    abreviacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    id_estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_id_pk", x => x.id_rol);
                    table.ForeignKey(
                        name: "estado_id_fk",
                        column: x => x.id_estado,
                        principalSchema: "Generico",
                        principalTable: "estado",
                        principalColumn: "id_estado");
                });

            migrationBuilder.CreateTable(
                name: "productos",
                schema: "Ventas",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    derivar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_img = table.Column<int>(type: "int", nullable: false)
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
                name: "persona_juridicas",
                schema: "Usuarios",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    razon_social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nombre_comercial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("persona_juridica_id_pk", x => x.id_persona);
                    table.ForeignKey(
                        name: "persona_id_fk",
                        column: x => x.id_persona,
                        principalSchema: "Usuarios",
                        principalTable: "personas",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "persona_natural",
                schema: "Usuarios",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    primer_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    segundo_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    apellido_paterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    apellido_materno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("persona_natural_id_pk", x => x.id_persona);
                    table.ForeignKey(
                        name: "personas_id_fk",
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
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    id_tipo_transaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("voucher_id_pk", x => x.id_voucher);
                    table.ForeignKey(
                        name: "estados_id_fk",
                        column: x => x.id_estado,
                        principalSchema: "Generico",
                        principalTable: "estado",
                        principalColumn: "id_estado");
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
                name: "detalle_dash_menu",
                schema: "Usuarios",
                columns: table => new
                {
                    id_menu = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_dash_menu_id_pk", x => new { x.id_menu, x.id_rol });
                    table.ForeignKey(
                        name: "menu_id_fk",
                        column: x => x.id_menu,
                        principalSchema: "Usuarios",
                        principalTable: "menu_dash",
                        principalColumn: "id_menu");
                    table.ForeignKey(
                        name: "rol_id_fk",
                        column: x => x.id_rol,
                        principalSchema: "Usuarios",
                        principalTable: "roles",
                        principalColumn: "id_rol");
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
                    id_img = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cambiar_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                        name: "personas_usuario_id_fk",
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
                name: "sucursal",
                schema: "Generico",
                columns: table => new
                {
                    id_sucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ambiente = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    id_ubigeo = table.Column<int>(type: "int", nullable: false),
                    id_documento = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "ubigeo_id_fk",
                        column: x => x.id_ubigeo,
                        principalSchema: "Generico",
                        principalTable: "ubigeo",
                        principalColumn: "id_ubigeo");
                });

            migrationBuilder.CreateTable(
                name: "compra",
                schema: "Almacen",
                columns: table => new
                {
                    id_compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_proveedor = table.Column<int>(type: "int", nullable: false),
                    id_voucher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("compra_id_pk", x => x.id_compra);
                    table.ForeignKey(
                        name: "provedor_id_fk",
                        column: x => x.id_proveedor,
                        principalSchema: "Almacen",
                        principalTable: "proveedor",
                        principalColumn: "id_proveedor");
                    table.ForeignKey(
                        name: "voucher_id_fk",
                        column: x => x.id_voucher,
                        principalSchema: "Ventas",
                        principalTable: "voucher",
                        principalColumn: "id_voucher");
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
                    id_sucursal = table.Column<int>(type: "int", nullable: false)
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
                    id_sucursal = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("producto_local_id_pk", x => x.id_producto_sucursal);
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
                name: "detalle_compra",
                schema: "Almacen",
                columns: table => new
                {
                    id_compra = table.Column<int>(type: "int", nullable: false),
                    id_insumo = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    precio_compra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    fecha_expiracion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_compra_id_pk", x => new { x.id_compra, x.id_insumo });
                    table.ForeignKey(
                        name: "compra_id_fk",
                        column: x => x.id_compra,
                        principalSchema: "Almacen",
                        principalTable: "compra",
                        principalColumn: "id_compra");
                    table.ForeignKey(
                        name: "insumo_id_fk",
                        column: x => x.id_insumo,
                        principalSchema: "Almacen",
                        principalTable: "insumo",
                        principalColumn: "id_insumo");
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                schema: "Ventas",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_apertura = table.Column<int>(type: "int", nullable: false),
                    id_voucher = table.Column<int>(type: "int", nullable: false),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    id_empleado = table.Column<int>(type: "int", nullable: false),
                    id_metodo = table.Column<int>(type: "int", nullable: false),
                    id_comprobante = table.Column<int>(type: "int", nullable: false),
                    nro_documento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nro_serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_tipo_pedido = table.Column<int>(type: "int", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
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
                        name: "estado_id_fk",
                        column: x => x.id_estado,
                        principalSchema: "Generico",
                        principalTable: "estado",
                        principalColumn: "id_estado");
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
                    id_estado = table.Column<int>(type: "int", nullable: false)
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
                        name: "estado_id_fk",
                        column: x => x.id_estado,
                        principalSchema: "Generico",
                        principalTable: "estado",
                        principalColumn: "id_estado");
                    table.ForeignKey(
                        name: "inventario_id_fk",
                        column: x => x.id_inventario,
                        principalSchema: "Almacen",
                        principalTable: "inventario",
                        principalColumn: "id_inventario");
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                schema: "Almacen",
                columns: table => new
                {
                    id_inventario = table.Column<int>(type: "int", nullable: false),
                    id_compra = table.Column<int>(type: "int", nullable: false),
                    fecha_Ingreso = table.Column<DateTime>(type: "datetime", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("entrada_id_pk", x => new { x.id_inventario, x.id_compra });
                    table.ForeignKey(
                        name: "compras_id_fk",
                        column: x => x.id_compra,
                        principalSchema: "Almacen",
                        principalTable: "compra",
                        principalColumn: "id_compra");
                    table.ForeignKey(
                        name: "inventario_id_entrada_fk",
                        column: x => x.id_inventario,
                        principalSchema: "Almacen",
                        principalTable: "inventario",
                        principalColumn: "id_inventario");
                });

            migrationBuilder.CreateTable(
                name: "detalle_produccion",
                schema: "Produccion",
                columns: table => new
                {
                    id_produccion = table.Column<int>(type: "int", nullable: false),
                    id_producto_sucursal = table.Column<int>(type: "int", nullable: false),
                    cantidad_salida = table.Column<int>(type: "int", nullable: true),
                    fecha_salida = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_produccion_id_pk", x => new { x.id_produccion, x.id_producto_sucursal });
                    table.ForeignKey(
                        name: "produccion_id_fk",
                        column: x => x.id_produccion,
                        principalSchema: "Produccion",
                        principalTable: "produccion",
                        principalColumn: "id_produccion");
                    table.ForeignKey(
                        name: "sucurusal_id_fk",
                        column: x => x.id_producto_sucursal,
                        principalSchema: "Ventas",
                        principalTable: "producto_sucursal",
                        principalColumn: "id_producto_sucursal");
                });

            migrationBuilder.CreateTable(
                name: "detalle_ventas",
                schema: "Ventas",
                columns: table => new
                {
                    id_det_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    id_venta = table.Column<int>(type: "int", nullable: false),
                    id_producto_sucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalle_venta_id_pk", x => x.id_det_venta);
                    table.ForeignKey(
                        name: "producto_sucursal_id_fk",
                        column: x => x.id_producto_sucursal,
                        principalSchema: "Ventas",
                        principalTable: "producto_sucursal",
                        principalColumn: "id_producto_sucursal");
                    table.ForeignKey(
                        name: "venta_id_fk",
                        column: x => x.id_venta,
                        principalSchema: "Ventas",
                        principalTable: "ventas",
                        principalColumn: "id_venta");
                });

            migrationBuilder.CreateTable(
                name: "salidas",
                schema: "Produccion",
                columns: table => new
                {
                    id_det_inventario = table.Column<int>(type: "int", nullable: false),
                    id_produccion = table.Column<int>(type: "int", nullable: false),
                    id_sucursal = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("salida_id_pk", x => new { x.id_det_inventario, x.id_produccion, x.id_sucursal });
                    table.ForeignKey(
                        name: "det_inventario_id_fk",
                        column: x => x.id_det_inventario,
                        principalSchema: "Almacen",
                        principalTable: "detalle_inventario",
                        principalColumn: "id_det_inventario");
                    table.ForeignKey(
                        name: "produccion_salida_id_fk",
                        column: x => x.id_produccion,
                        principalSchema: "Produccion",
                        principalTable: "produccion",
                        principalColumn: "id_produccion");
                    table.ForeignKey(
                        name: "sucursal_id_fk",
                        column: x => x.id_sucursal,
                        principalSchema: "Generico",
                        principalTable: "sucursal",
                        principalColumn: "id_sucursal");
                });

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
                name: "IX_compra_id_proveedor",
                schema: "Almacen",
                table: "compra",
                column: "id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_compra_id_voucher",
                schema: "Almacen",
                table: "compra",
                column: "id_voucher");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_id_insumo",
                schema: "Almacen",
                table: "detalle_compra",
                column: "id_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_dash_menu_id_rol",
                schema: "Usuarios",
                table: "detalle_dash_menu",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_inventario_id_estado",
                schema: "Almacen",
                table: "detalle_inventario",
                column: "id_estado");

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
                name: "IX_detalle_produccion_id_producto_sucursal",
                schema: "Produccion",
                table: "detalle_produccion",
                column: "id_producto_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_ventas_id_producto_sucursal",
                schema: "Ventas",
                table: "detalle_ventas",
                column: "id_producto_sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_ventas_id_venta",
                schema: "Ventas",
                table: "detalle_ventas",
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
                name: "IX_entradas_id_compra",
                schema: "Almacen",
                table: "entradas",
                column: "id_compra");

            migrationBuilder.CreateIndex(
                name: "estado_descripcion_uk",
                schema: "Generico",
                table: "estado",
                column: "nombre",
                unique: true,
                filter: "[nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_estado_id_estado_padre",
                schema: "Generico",
                table: "estado",
                column: "id_estado_padre");

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
                name: "IX_roles_id_estado",
                schema: "Usuarios",
                table: "roles",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_salidas_id_produccion",
                schema: "Produccion",
                table: "salidas",
                column: "id_produccion");

            migrationBuilder.CreateIndex(
                name: "IX_salidas_id_sucursal",
                schema: "Produccion",
                table: "salidas",
                column: "id_sucursal");

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
                name: "IX_sucursal_id_ubigeo",
                schema: "Generico",
                table: "sucursal",
                column: "id_ubigeo");

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
                name: "IX_ventas_id_estado",
                schema: "Ventas",
                table: "ventas",
                column: "id_estado");

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
                name: "IX_voucher_id_estado",
                schema: "Ventas",
                table: "voucher",
                column: "id_estado");

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
                name: "detalle_compra",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "detalle_dash_menu",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "detalle_produccion",
                schema: "Produccion");

            migrationBuilder.DropTable(
                name: "detalle_ventas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "entradas",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "persona_juridicas",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "persona_natural",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "salidas",
                schema: "Produccion");

            migrationBuilder.DropTable(
                name: "sucursal_usuario",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "menu_dash",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "producto_sucursal",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "ventas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "compra",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "detalle_inventario",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "produccion",
                schema: "Produccion");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "categorias",
                schema: "Almacen");

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
                name: "proveedor",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "voucher",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "insumo",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "inventario",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "imagenes",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "cajas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "personas",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "tipo_transaccion",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "unidad_medicion",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "sucursal",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "estado",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "ambiente",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "documentos",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "ubigeo",
                schema: "Generico");

            migrationBuilder.DropTable(
                name: "mesas",
                schema: "Ventas");

            migrationBuilder.DropTable(
                name: "tipo_comprobantes",
                schema: "Ventas");
        }
    }
}
