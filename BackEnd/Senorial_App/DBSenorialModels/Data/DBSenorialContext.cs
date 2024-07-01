using System;
using System.Collections.Generic;
using DBSenorialModels.Senorial;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBSenorialModels.Data;

public partial class DBSenorialContext : DbContext
{
    public DBSenorialContext()
    {
    }

    public DBSenorialContext(DbContextOptions<DBSenorialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ambiente> Ambientes { get; set; }

    public virtual DbSet<AperturaCaja> AperturaCajas { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleDashMenu> DetalleDashMenus { get; set; }

    public virtual DbSet<DetalleInventario> DetalleInventarios { get; set; }

    public virtual DbSet<DetalleProduccion> DetalleProduccions { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    //public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<MenuDash> MenuDashes { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    //public virtual DbSet<PersonaJuridica> PersonaJuridicas { get; set; }

    //public virtual DbSet<PersonaNatural> PersonaNaturals { get; set; }

    public virtual DbSet<Produccion> Produccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoSucursal> ProductoSucursals { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salida> Salidas { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<SucursalUsuario> SucursalUsuarios { get; set; }

    public virtual DbSet<TipoComprobante> TipoComprobantes { get; set; }

    public virtual DbSet<TipoPedido> TipoPedidos { get; set; }
    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<UnidadMedicion> UnidadMedicions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
        configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
        IConfiguration configurationFile = configurationBuild.Build();

        optionsBuilder.EnableSensitiveDataLogging();
        string conneccion = configurationFile.GetConnectionString("DBSenorial");
        optionsBuilder.UseSqlServer(conneccion);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ambiente>(entity =>
        {
            entity.HasKey(e => e.IdAmbiente).HasName("ambiente_id_pk");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Ambientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mesa_id_fk");
        });

        modelBuilder.Entity<AperturaCaja>(entity =>
        {
            entity.HasKey(e => e.IdApertura).HasName("apertura_caja_id_pk");

            entity.HasOne(d => d.IdCajaNavigation).WithMany(p => p.AperturaCajas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("caja_id_fk");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.IdCaja).HasName("caja_id_pk");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("categoria_id_pk");

            entity.HasOne(d => d.IdCategoriaPadreNavigation).WithMany(p => p.InverseIdCategoriaPadreNavigation).HasConstraintName("categorias_padre_fk");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("cliente_id_pk");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persona_id_fk");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("compra_id_pk");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provedor_id_fk");

            entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("voucher_id_fk");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => new { e.IdCompra, e.IdInsumo }).HasName("detalle_compra_id_pk");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compra_id_fk");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("insumo_id_fk");
            

            
        });

        modelBuilder.Entity<DetalleDashMenu>(entity =>
        {
            entity.HasKey(e => new { e.IdMenu, e.IdRol }).HasName("detalle_dash_menu_id_pk");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.DetalleDashMenus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menu_id_fk");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.DetalleDashMenus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rol_id_fk");
        });

        modelBuilder.Entity<DetalleInventario>(entity =>
        {
            entity.HasKey(e => e.IdDetInventario).HasName("detalle_inventario_id_pk");

            //entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.DetalleInventarios)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("estado_id_fk");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleInventarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("det_insumo_id_fk");

            entity.HasOne(d => d.IdInventarioNavigation).WithMany(p => p.DetalleInventarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_id_fk");
        });

        modelBuilder.Entity<DetalleProduccion>(entity =>
        {
            entity.HasKey(e => new { e.IdProduccion, e.IdProductoSucursal }).HasName("detalle_produccion_id_pk");

            entity.HasOne(d => d.IdProduccionNavigation).WithMany(p => p.DetalleProduccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("produccion_id_fk");

            entity.HasOne(d => d.IdProductoSucursalNavigation).WithMany(p => p.DetalleProduccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucurusal_id_fk");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetVenta).HasName("detalle_venta_id_pk");

            entity.HasOne(d => d.IdProductoSucursalNavigation).WithMany(p => p.DetalleVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_sucursal_id_fk");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("venta_id_fk");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("documento_id_pk");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comprobante_tipo_id_fk");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("empleado_id_pk");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_persona_id_fk");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rol_id_fk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_id_fk");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => new { e.IdInventario, e.IdCompra }).HasName("entrada_id_pk");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.Entrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compras_id_fk");

            entity.HasOne(d => d.IdInventarioNavigation).WithMany(p => p.Entrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_id_entrada_fk");
        });


        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.IdImg).HasName("imagenes_id_pk");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("insumo_id_pk");

            entity.HasOne(d => d.IdUnidadNavigation).WithMany(p => p.Insumos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unidad_medida_id_fk");
            entity.HasData(
            new Insumo { IdInsumo = 1,  Nombre = "Aceite", IdUnidad = 1 }, // Balde
            new Insumo { IdInsumo = 2,  Nombre = "Aceite", IdUnidad = 2 }, // Litro
            new Insumo { IdInsumo = 3,  Nombre = "Aceite Sésamo", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 4,  Nombre = "Aji", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 5,  Nombre = "Ajicero", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 6,  Nombre = "Arroz con leche", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 7,  Nombre = "Azucar Blanca", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 8,  Nombre = "Azucar Rubia", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 9,  Nombre = "Bolsa Basura", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 10, Nombre = "Bolsa Cuarto Pollo", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 11, Nombre = "Bolsa Ensalada", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 12, Nombre = "Bolsa Medio Pollo", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 13, Nombre = "Bolsa Pollo Entero", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 14, Nombre = "Bolsa Rollo Pollo", IdUnidad = 6 }, // Rollo
            new Insumo { IdInsumo = 15, Nombre = "Café Sobre", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 16, Nombre = "Caja ligas", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 17, Nombre = "Carbón", IdUnidad = 7 }, // Bolsa 5 kg
            new Insumo { IdInsumo = 18, Nombre = "Cebolla", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 19, Nombre = "Cebolla China", IdUnidad = 8 }, // Atado
            new Insumo { IdInsumo = 20, Nombre = "Champiñon lata", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 21, Nombre = "Chicha Morada", IdUnidad = 9 }, // Bolsa
            new Insumo { IdInsumo = 22, Nombre = "Conserva Durazno", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 23, Nombre = "Espinaca", IdUnidad = 8 }, // Atado
            new Insumo { IdInsumo = 24, Nombre = "Fideo Spaguetti", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 25, Nombre = "Fósforo", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 26, Nombre = "Fresa", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 27, Nombre = "Gas", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 28, Nombre = "Hierba Buena", IdUnidad = 8 }, // Atado
            new Insumo { IdInsumo = 29, Nombre = "Huevo", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 30, Nombre = "Ketchup", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 31, Nombre = "Leche", IdUnidad = 2 }, // Litro
            new Insumo { IdInsumo = 32, Nombre = "Leche Evaporada", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 33, Nombre = "Leche Fresca", IdUnidad = 2 }, // Litro
            new Insumo { IdInsumo = 34, Nombre = "Lechuga", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 35, Nombre = "Leña", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 36, Nombre = "Limón", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 37, Nombre = "Lonja", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 38, Nombre = "Mates General", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 39, Nombre = "Mayonesa", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 40, Nombre = "Milo lata", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 41, Nombre = "Mondadiente", IdUnidad = 10 }, // Caja
            new Insumo { IdInsumo = 42, Nombre = "Mostaza", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 43, Nombre = "Ostión", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 44, Nombre = "Pan", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 45, Nombre = "Panetón", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 46, Nombre = "Papa", IdUnidad = 11 }, // Bolsa 20 kg
            new Insumo { IdInsumo = 47, Nombre = "Papaya", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 48, Nombre = "Papel Manteca", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 49, Nombre = "Pepino", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 50, Nombre = "Pimenton", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 51, Nombre = "Pisco", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 52, Nombre = "Pollo", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 53, Nombre = "Plátano", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 54, Nombre = "Queso molde", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 55, Nombre = "Queso Parmesano", IdUnidad = 3 },// Unidad
            new Insumo { IdInsumo = 56, Nombre = "Refresco Maracuya", IdUnidad = 9 }, // Bolsa
            new Insumo { IdInsumo = 57, Nombre = "Ron", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 58, Nombre = "Salsa de Tomate", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 59, Nombre = "Sillao", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 60, Nombre = "Taper 6 u 8 Ensalada", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 61, Nombre = "Taper Cuarto Pollo", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 62, Nombre = "Taper Ensalada Entero", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 63, Nombre = "Taper Medio Pollo", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 64, Nombre = "Taper Pollo Entero", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 65, Nombre = "Tomate", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 66, Nombre = "Vaso Plástico Flan", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 67, Nombre = "Vaso Plástico Gelatina", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 68, Nombre = "Vaso Vidrio Flan", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 69, Nombre = "Vaso Vidrio Gelatina", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 70, Nombre = "Vinagre", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 71, Nombre = "Vinagreta", IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 72, Nombre = "Vino", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 73, Nombre = "Whiski", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 74, Nombre = "Yuquitas", IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 75, Nombre = "Zanahoria", IdUnidad = 4 } // Kilo
        );
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("inventario_id_pk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Inventarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_id_fk");
        });

        modelBuilder.Entity<MenuDash>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("dashboard_id_pk");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("mesa_id_pk");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("metodo_pago_id_pk");
            entity.HasData(
                new MetodoPago { IdMetodo = 1, Descripcion = "Efectivo" },
                new MetodoPago { IdMetodo = 2, Descripcion = "Tarjeta" },
                new MetodoPago { IdMetodo = 3, Descripcion = "Transferencia" },
                new MetodoPago { IdMetodo = 4, Descripcion = "Descuento" },
                new MetodoPago { IdMetodo = 5, Descripcion = "Otros" }
            );
        });
        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("tipo_documento", "Usuarios"); // Tabla y esquema
            entity.HasKey(e => e.IdTipoDocumento).HasName("tipo_documento_id_pk"); // Clave primaria

            // Datos de ejemplo para TipoDocumento
            entity.HasData(
                new TipoDocumento { IdTipoDocumento = 1, Nombre = "DNI" },
                new TipoDocumento { IdTipoDocumento = 2, Nombre = "RUC" },
                new TipoDocumento { IdTipoDocumento = 3, Nombre = "Pasaporte" },
                new TipoDocumento { IdTipoDocumento = 4, Nombre = "Carnet de Extranjería" }
            );
        });
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("personas", "Usuarios"); // Tabla y esquema
            entity.HasKey(e => e.IdPersona).HasName("persona_id_pk");
            entity.HasOne(e => e.IdTipoDocumentoNavigation).WithMany(p=> p.Personas)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tipo_documentos_id_fk");

            entity.HasData(
                new Persona
                {
                    IdPersona = 1,
                    PrimerNombre = "Victor",
                    SegundoNombre = "",
                    ApellidoPaterno = "Abregu",
                    ApellidoMaterno = "",
                    NroDocumento = "",
                    Email = "admin@admin.com",
                    Telefono = "985851866",
                    Direccion = "",
                    IdTipoDocumento = 1, // ID de tipo de documento según los datos de ejemplo
                    Genero = "Masculino",
                    TipoPersona = "Natural",
                    RazonSocial = "Señorial"
                }
            );
        });

        modelBuilder.Entity<Produccion>(entity =>
        {
            entity.HasKey(e => e.IdProduccion).HasName("produccion_id_pk");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("producto_id_pk");

            entity.HasOne(d => d.IdImgNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("img_id_fk");
        });

        modelBuilder.Entity<ProductoSucursal>(entity =>
        {
            entity.HasKey(e => e.IdProductoSucursal).HasName("producto_local_id_pk");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.ProductoSucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorias_id_fk");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoSucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_id_fk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.ProductoSucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursales_id_fk");

            entity.HasOne(d => d.IdUnidadNavigation).WithMany(p => p.ProductoSucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unidad_medida_id_fk");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("proveedor_id_pk");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Proveedors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_id_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("roles_id_pk");
            
            entity.HasData(
           new Role { IdRol = 1, Nombre = "Administrador", Estado = "Activo" }, 
           new Role { IdRol = 2, Nombre = "Desarrollador", Estado = "Activo" }, 
           new Role { IdRol = 3, Nombre = "Cajero", Estado = "Activo" }, 
           new Role { IdRol = 4, Nombre = "Mozo", Estado = "Activo" }, 
           new Role { IdRol = 5, Nombre = "Cliente", Estado = "Activo" } 
       );
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => new { e.IdDetInventario, e.IdProduccion, e.IdSucursal }).HasName("salida_id_pk");

            entity.HasOne(d => d.IdDetInventarioNavigation).WithMany(p => p.Salida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("det_inventario_id_fk");

            entity.HasOne(d => d.IdProduccionNavigation).WithMany(p => p.Salida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("produccion_salida_id_fk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Salida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_id_fk");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("sucursal_id_pk");

            entity.HasOne(d => d.IdAmbienteNavigation).WithMany(p => p.Sucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ambientes_id_fk");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Sucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documento_id_fk");
            entity.HasData(
                new Sucursal {IdSucursal = 1 , Nombre = "Pio Pata",Direccion = ""},
                new Sucursal {IdSucursal = 2 , Nombre = "Chilca", Direccion = "" }
                );

        });

        modelBuilder.Entity<SucursalUsuario>(entity =>
        {
            entity.HasKey(e => new { e.IdSucursal, e.IdUsuario }).HasName("sucursal_id_usuario_pk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SucursalUsuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_user_id_fk");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.SucursalUsuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_id_fk");
        });

        modelBuilder.Entity<TipoComprobante>(entity =>
        {
            entity.HasKey(e => e.IdComprobante).HasName("tipo_comprobante_id_pk");
        });

        modelBuilder.Entity<TipoPedido>(entity =>
        {
            entity.HasKey(e => e.IdTipoPedido).HasName("tipo_pedido_id_pk");
            entity.HasData(
            new TipoPedido { IdTipoPedido = 1, Descripcion = "Para Comer Aqui" },
            new TipoPedido { IdTipoPedido = 2, Descripcion = "Para Llevar" });
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdTipoTransaccion).HasName("tipo_transaccion_id_pk");
        });


        modelBuilder.Entity<UnidadMedicion>(entity =>
        {
            entity.HasKey(e => e.IdUnidad).HasName("unidad_medicion_id_pk");
            entity.HasData(
        new UnidadMedicion { IdUnidad = 1, Abreviacion = "Balde", Descripcion = "Balde" },
        new UnidadMedicion { IdUnidad = 2, Abreviacion = "Lt", Descripcion = "Litro" },
        new UnidadMedicion { IdUnidad = 3, Abreviacion = "Und", Descripcion = "Unidad" },
        new UnidadMedicion { IdUnidad = 4, Abreviacion = "Kg", Descripcion = "Kilo" },
        new UnidadMedicion { IdUnidad = 5, Abreviacion = "Cto", Descripcion = "Ciento" },
        new UnidadMedicion { IdUnidad = 6, Abreviacion = "Rllo", Descripcion = "Rollo" },
        new UnidadMedicion { IdUnidad = 7, Abreviacion = "B-5Kg", Descripcion = "Bolsa 5 kg" },
        new UnidadMedicion { IdUnidad = 8, Abreviacion = "At", Descripcion = "Atado" },
        new UnidadMedicion { IdUnidad = 9, Abreviacion = "Bsa", Descripcion = "Bolsa" },
        new UnidadMedicion { IdUnidad = 10, Abreviacion = "Cja", Descripcion = "Caja" },
        new UnidadMedicion { IdUnidad = 11, Abreviacion = "B-20Kg", Descripcion = "Bolsa 20 kg" }
    );
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuario_id_pk");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdImgNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("img_id_fk");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personas_usuarios_id_fk");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roles_id_fk");
            entity.HasData(
            new Usuario
            {
                IdUsuario = 1,
                CambiarPassword = "", // Asignación temporal para el ejemplo
                CreatedAt = DateTime.Now,
                Email = "admin@admin.com",
                IdRol = 1, // Asigna el Id del rol de Administrador
                IdPersona = 1, // Asigna el Id de la persona asociada al usuario
                Password = "eQEguXgFEjSmgVeXYX+rexPeMAQ7AOMpdD8MPNqCe6s=", // Admin-Victor1
                UserName = "admin"
            }
        );
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("venta_id_pk");

            entity.Property(e => e.FechaVenta).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdAperturaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdApertura) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("apertura_caja_id_fk");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cliente_id_fk");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdComprobante) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comprobante_id_fk");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_id_fk");

            entity.HasOne(d => d.IdMetodoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdMetodo) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("metodo_id_fk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdSucursal) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursales_ventas_id_fk");

            entity.HasOne(d => d.IdTipoPedidoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoPedido) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_pedido_id_fk");

            entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdVoucher) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("voucher_id_fk");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.IdVoucher).HasName("voucher_id_pk");

            //entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Vouchers)
            //    .HasForeignKey(d => d.IdEstado) // Añadir clave foránea explícitamente
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("estados_id_fk");

            entity.HasOne(d => d.IdTipoTransaccionNavigation).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.IdTipoTransaccion) // Añadir clave foránea explícitamente
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_transaccion_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
