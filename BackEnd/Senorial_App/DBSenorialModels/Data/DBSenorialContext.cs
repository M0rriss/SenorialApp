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

    //public virtual DbSet<Compra> Compras { get; set; }
    public virtual DbSet<ConteoDinero> ConteoDinero { get; set; }


    public virtual DbSet<DetalleInventario> DetalleInventarios { get; set; }

    //public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
    //public virtual DbSet<DetalleProduccion> DetalleProduccions { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }


    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    //public virtual DbSet<Produccion> Produccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoSucursal> ProductoSucursals { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }
    public virtual DbSet<Pedido> Pedidos { get; set; }
    public virtual DbSet<PedidoLlevar> PedidosLlevar { get; set; }
    public virtual DbSet<DetallePedidoLlevar> DetallePedidosLlevar { get; set; }

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
            entity.HasMany(e => e.Conteos)
          .WithOne(e => e.AperturaCaja)
          .HasForeignKey(e => e.IdApertura)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("apertura_caja_conteo_fk");

        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.IdCaja).HasName("caja_id_pk");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("categoria_id_pk");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Estado)
                .IsRequired();

            entity.HasOne(d => d.CategoriaPadre)
                .WithMany(p => p.SubCategorias)
                .HasForeignKey(d => d.IdCategoriaPadre)
                .HasConstraintName("categorias_padre_fk");

            entity.HasMany(d => d.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categoria_producto_fk");
            entity.HasData(
        new Categoria { IdCategoria = 1, Nombre = "Hamburguesa" ,       Estado = true },
        new Categoria { IdCategoria = 2, Nombre = "Parrillas y Pollos", Estado = true },
        new Categoria { IdCategoria = 3, Nombre = "Platos de Fondo",    Estado = true },
        new Categoria { IdCategoria = 4, Nombre = "Bebidas",            Estado = true },
        new Categoria { IdCategoria = 5, Nombre = "Complementos",       Estado = true }
    );

    entity.HasData(
        new Categoria { IdCategoria =  6, Nombre = "Pollos",              Estado = true, IdCategoriaPadre = 2 },
        new Categoria { IdCategoria =  7, Nombre = "Parrillas",           Estado = true, IdCategoriaPadre = 2 },
        new Categoria { IdCategoria =  8, Nombre = "Otros",               Estado = true, IdCategoriaPadre = 2 },
        new Categoria { IdCategoria =  9, Nombre = "Comida Rápida",       Estado = true, IdCategoriaPadre = 3 },
        new Categoria { IdCategoria = 10, Nombre = "Bebidas Calientes",   Estado = true, IdCategoriaPadre = 4 },
        new Categoria { IdCategoria = 11, Nombre = "Bebidas Frías",       Estado = true, IdCategoriaPadre = 4 },
        new Categoria { IdCategoria = 12, Nombre = "Licores",             Estado = true, IdCategoriaPadre = 4 },
        new Categoria { IdCategoria = 13, Nombre = "Cócteles",            Estado = true, IdCategoriaPadre = 4 },
        new Categoria { IdCategoria = 14, Nombre = "Piqueos de la Casa",  Estado = true, IdCategoriaPadre = 3 },
        new Categoria { IdCategoria = 15, Nombre = "Postres",             Estado = true, IdCategoriaPadre = 5 },
        new Categoria { IdCategoria = 16, Nombre = "Jugos y Milkshakes",  Estado = true, IdCategoriaPadre = 5 },
        new Categoria { IdCategoria = 17, Nombre = "Hamburguesas"       , Estado = true, IdCategoriaPadre = 1 }
    );
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("cliente_id_pk");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persona_id_fk");
        });

        //modelBuilder.Entity<Compra>(entity =>
        //{
        //    entity.HasKey(e => e.IdCompra).HasName("compra_id_pk");

        //    entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("provedor_id_fk");

        //    entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.Compras)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("voucher_id_fk");
        //});
        modelBuilder.Entity<ConteoDinero>(entity =>
        {
            entity.HasKey(e => e.IdConteo).HasName("conteo_dinero_id_pk");

            entity.HasOne(d => d.AperturaCaja)
                  .WithMany(p => p.Conteos)
                  .HasForeignKey(d => d.IdApertura)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("conteo_dinero_apertura_fk");
        });

        //modelBuilder.Entity<DetalleCompra>(entity =>
        //{
        //    entity.HasKey(e => new { e.IdCompra, e.IdInsumo }).HasName("detalle_compra_id_pk");

        //    entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("compra_id_fk");

        //    entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleCompras)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("insumo_id_fk");


        modelBuilder.Entity<DetalleInventario>(entity =>
        {
            entity.HasKey(e => e.IdDetInventario).HasName("detalle_inventario_id_pk");

            entity.HasOne(d => d.Insumo)
                .WithMany(p => p.DetalleInventarios)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("det_insumo_id_fk");

            entity.HasOne(d => d.Inventario)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.IdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_id_fk");

            entity.HasData(
                new DetalleInventario() { IdDetInventario = 1,  IdInventario = 1,  IdInsumo = 1,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 2,  IdInventario = 1,  IdInsumo = 2,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 3,  IdInventario = 1,  IdInsumo = 3,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 4,  IdInventario = 1,  IdInsumo = 4,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 5,  IdInventario = 1,  IdInsumo = 5,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 6,  IdInventario = 1,  IdInsumo = 6,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 7,  IdInventario = 1,  IdInsumo = 7,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 8,  IdInventario = 1,  IdInsumo = 8,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 9,  IdInventario = 1,  IdInsumo = 9,   StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 10, IdInventario = 1,  IdInsumo = 10,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 11, IdInventario = 1,  IdInsumo = 11,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 12, IdInventario = 1,  IdInsumo = 12,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 13, IdInventario = 1,  IdInsumo = 13,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 14, IdInventario = 1,  IdInsumo = 14,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 15, IdInventario = 1,  IdInsumo = 15,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 16, IdInventario = 1,  IdInsumo = 16,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 17, IdInventario = 1,  IdInsumo = 17,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 18, IdInventario = 1,  IdInsumo = 18,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 19, IdInventario = 1,  IdInsumo = 19,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 20, IdInventario = 1,  IdInsumo = 20,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 21, IdInventario = 1,  IdInsumo = 21,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 22, IdInventario = 1,  IdInsumo = 22,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 23, IdInventario = 1,  IdInsumo = 23,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 24, IdInventario = 1,  IdInsumo = 24,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 25, IdInventario = 1,  IdInsumo = 25,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 26, IdInventario = 1,  IdInsumo = 26,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 27, IdInventario = 1,  IdInsumo = 27,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 28, IdInventario = 1,  IdInsumo = 28,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 29, IdInventario = 1,  IdInsumo = 29,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 30, IdInventario = 1,  IdInsumo = 30,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 31, IdInventario = 1,  IdInsumo = 31,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 32, IdInventario = 1,  IdInsumo = 32,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 33, IdInventario = 1,  IdInsumo = 33,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 34, IdInventario = 1,  IdInsumo = 34,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 35, IdInventario = 1,  IdInsumo = 35,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 36, IdInventario = 1,  IdInsumo = 36,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 37, IdInventario = 1,  IdInsumo = 37,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 38, IdInventario = 1,  IdInsumo = 38,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 39, IdInventario = 1,  IdInsumo = 39,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 40, IdInventario = 1,  IdInsumo = 40,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 41, IdInventario = 1,  IdInsumo = 41,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 42, IdInventario = 1,  IdInsumo = 42,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 43, IdInventario = 1,  IdInsumo = 43,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 44, IdInventario = 1,  IdInsumo = 44,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 45, IdInventario = 1,  IdInsumo = 45,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 46, IdInventario = 1,  IdInsumo = 46,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 47, IdInventario = 1,  IdInsumo = 47,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 48, IdInventario = 1,  IdInsumo = 48,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 49, IdInventario = 1,  IdInsumo = 49,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 50, IdInventario = 1,  IdInsumo = 50,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 51, IdInventario = 1,  IdInsumo = 51,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 52, IdInventario = 1,  IdInsumo = 52,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 53, IdInventario = 1,  IdInsumo = 53,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 54, IdInventario = 1,  IdInsumo = 54,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 55, IdInventario = 1,  IdInsumo = 55,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 56, IdInventario = 1,  IdInsumo = 56,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 57, IdInventario = 1,  IdInsumo = 57,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 58, IdInventario = 1,  IdInsumo = 58,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 59, IdInventario = 1,  IdInsumo = 59,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 60, IdInventario = 1,  IdInsumo = 60,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 61, IdInventario = 1,  IdInsumo = 61,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 62, IdInventario = 1,  IdInsumo = 62,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 63, IdInventario = 1,  IdInsumo = 63,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 64, IdInventario = 1,  IdInsumo = 64,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 65, IdInventario = 1,  IdInsumo = 65,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 66, IdInventario = 1,  IdInsumo = 66,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 67, IdInventario = 1,  IdInsumo = 67,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 68, IdInventario = 1,  IdInsumo = 68,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 69, IdInventario = 1,  IdInsumo = 69,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 70, IdInventario = 1,  IdInsumo = 70,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 71, IdInventario = 1,  IdInsumo = 71,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 72, IdInventario = 1,  IdInsumo = 72,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 73, IdInventario = 1,  IdInsumo = 73,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 74, IdInventario = 1,  IdInsumo = 74,  StockTotal = 12, IdEstado = 1 },
                new DetalleInventario() { IdDetInventario = 75, IdInventario = 1,  IdInsumo = 75,  StockTotal = 12, IdEstado = 1 }
                );
        });

        //modelBuilder.Entity<DetalleProduccion>(entity =>
        //{
        //    entity.HasKey(e => new { e.IdProduccion, e.IdProductoSucursal }).HasName("detalle_produccion_id_pk");

        //    entity.HasOne(d => d.IdProduccionNavigation).WithMany(p => p.DetalleProduccions)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("produccion_id_fk");

        //    entity.HasOne(d => d.IdProductoSucursalNavigation).WithMany(p => p.DetalleProduccions)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("sucurusal_id_fk");
        //});

        //modelBuilder.Entity<DetalleVenta>(entity =>
        //{
        //    entity.HasKey(e => e.IdDetVenta).HasName("detalle_venta_id_pk");

        //    entity.HasOne(d => d.IdProductoSucursalNavigation)
        //        .WithMany(p => p.DetalleVenta)
        //        .HasForeignKey(d => d.IdProductoSucursal)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("producto_sucursal_id_fk");

        //    entity.HasOne(d => d.IdVentaNavigation)
        //        .WithMany(p => p.DetalleVenta)
        //        .HasForeignKey(d => d.IdVenta)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("venta_id_fk");
        //});

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
            entity.HasKey(e => e.IdEntrada).HasName("entrada_id_pk");

            entity.HasOne(d => d.Inventario)
                .WithMany(p => p.Entradas)
                .HasForeignKey(d => d.IdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_id_entrada_fk");

            entity.HasOne(e => e.IdNavigationInsumo)
                .WithMany(e => e.Entrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("entrada_insumo_fk");
        });


        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("imagenes_id_pk");
            entity.HasData(
         new Imagene { Id = 1 , FileName  = "Hamburguesa-clasica"         , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-clasica_ggudid.png" },
         new Imagene { Id = 2 , FileName  = "Hamburguesa-queso-tocino"    , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-queso-tocino_li42kl.png" },
         new Imagene { Id = 3 , FileName  = "Hamburguesa-senorial"        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-senorial_qw9pko.png" },
         new Imagene { Id = 4 , FileName  = "1-4-de-pollo-a-la-brasa"     , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258861/Pollo-a-la-brasa-1-4_kh0xna.png" },
         new Imagene { Id = 5 , FileName  = "1-4-de-pollo-broaster"       , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258863/Pollo-broaster-1-4_bvqfwh.png" },
         new Imagene { Id = 6 , FileName  = "Parrilla-de-pollo"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo_mqiwcu.png" },
         new Imagene { Id = 7 , FileName  = "Parrilla-de-pollo-al-ajo"    , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo-al-ajo_zyzrtw.png" },
         new Imagene { Id = 8 , FileName  = "Parrilla-de-pollo-dietetica" , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo-dietetico_ym2r5n.png" },
         new Imagene { Id = 9 , FileName  = "Parrilla-mixta"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258858/Parrilla-mixta_ehhq5k.png" },
         new Imagene { Id = 10, FileName = "Brochetas-de-pollo"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258870/Brochetas-de-pollo_jmqtvn.png" },
         new Imagene { Id = 11, FileName = "Pollo-a-la-pizzarola"         , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pollo-a-la-pizzarola_orxsc5.png" },
         new Imagene { Id = 12, FileName = "Bisteck-a-la-parrilla"        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258870/Bisteck-a-la-parrilla_r9iclg.png" },
         new Imagene { Id = 13, FileName = "Chorizo-a-la-parrilla"        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Chorizo-a-la-parrilla_dgpnvt.png" },
         new Imagene { Id = 14, FileName = "Chicharron-senorial"          , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chicharron-senorial_p50hre.png" },
         new Imagene { Id = 15, FileName = "Lonjitas"                     , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258849/Lonjitas_xdukaq.png" },
         new Imagene { Id = 16, FileName = "Chaufa-especial"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258877/Chaufa-especial_alryv8.png" },
         new Imagene { Id = 17, FileName = "Chaufa-mixto"                 , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chaufa-mixto_ysfysw.png" },
         new Imagene { Id = 18, FileName = "Spaguetti-a-lo-alfredo"       , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Spaguetti-a-lo-alfredo_pyobkl.png" },
         new Imagene { Id = 19, FileName = "Cafe-pasado"                  , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Cafe-pasado_fks93h.png" },
         new Imagene { Id = 20, FileName = "Chocolate-con-panetón"        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Chocolate-con-paneton_nbteel.png" },
         new Imagene { Id = 21, FileName = "Leche-fresca"                 , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258846/Leche-fresca_tpj7mm.png" },
         new Imagene { Id = 22, FileName = "Milo"                         , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258852/Milo_yii8m1.png" },
         new Imagene { Id = 23, FileName = "Cafe-con-leche"               , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Cafe-con-leche_rrxkzt.png" },
         new Imagene { Id = 24, FileName = "Mates"                        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Mates_wcsite.png" },
         new Imagene { Id = 25, FileName = "Gaseosa-3lts"                 , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-3lts_el2kgx.png" },
         new Imagene { Id = 26, FileName = "Gaseosa-2.25lts"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Gaseosa-de-2.25lts_r780yp.png" },
         new Imagene { Id = 27, FileName = "Gaseosa-1.5lts"               , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Gaseosa-de-1.5lts_ajne1a.png" },
         new Imagene { Id = 28, FileName = "Gaseosa-1lts"                 , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-1lts_axqqpe.png" },
         new Imagene { Id = 29, FileName = "Gaseosa-1-2lt"                , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-500ml_m2rgju.png" },
         new Imagene { Id = 30, FileName = "Gaseosa-personal"             , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-personal_hnkmlf.png" },
         new Imagene { Id = 31, FileName = "Gaseosa-piranita"             , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-piranita_jv3ord.png" },
         new Imagene { Id = 32, FileName = "Refresco-de-maracuya-jarra"   , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258863/Refresco-de-maracuya-Jarra_aeakzt.png" },
         new Imagene { Id = 33, FileName = "Chicha-morada-jarra"          , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chicha-morada-Jarra_xsjncx.png" },
         new Imagene { Id = 34, FileName = "Limonada-Frozen-jarra"        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258848/Limonada-frozen-Jarra_xftmfy.png" },
         new Imagene { Id = 35, FileName = "Limonada-Americana-jarra"     , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258848/Limona-americana-Jarra_esgczd.png" },
         new Imagene { Id = 36, FileName = "Caliente-de-pisco"            , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Caliente-de-pisco_sjalzc.png" },
         new Imagene { Id = 37, FileName = "Caliente-de-vino"             , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258874/Caliente-de-vino_kwaift.png" },
         new Imagene { Id = 38, FileName = "Caliente-de-ron"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Caliente-de-ron_pg2g1m.png" },
         new Imagene { Id = 39, FileName = "Caliente-de-whisky"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Caliente-de-whisky_gpmkst.png" },
         new Imagene { Id = 40, FileName = "Cerveza-en-lata"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Cerveza-en-lata_qozyqi.png" },
         new Imagene { Id = 41, FileName = "Cerveza-negra"                , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258877/Cerveza-negra_kk7eux.png" },
         new Imagene { Id = 42, FileName = "Cerveza-de-trigo"             , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Cerveza-de-trigo_yabm3n.png" },
         new Imagene { Id = 43, FileName = "Vino-queirolo-vaso"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258867/Vino-queirolo-Vaso_kj8sbq.png" },
         new Imagene { Id = 44, FileName = "Whisky-vaso"                  , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258867/Wisky-Vaso_qnwn1m.png" },
         new Imagene { Id = 45, FileName = "Pisco-Vargas-vaso"            , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pisco-vargas-Vaso_t8y3oz.png" },
         new Imagene { Id = 46, FileName = "Mojito"                       , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258854/Mojito_ubvhpc.png" },
         new Imagene { Id = 47, FileName = "Machu-Picchu"                 , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258849/Machu-picchu_sosb2h.png" },
         new Imagene { Id = 48, FileName = "Daikiri"                      , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Daikiri_scg5iq.png" },
         new Imagene { Id = 49, FileName = "Pina-colada"                  , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pina-colada_qoav6s.png" },
         new Imagene { Id = 50, FileName = "Pisco-sour"                   , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pisco-sour_xhrnzd.png" },
         new Imagene { Id = 51, FileName = "Naranjita"                    , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258856/Naranjita_jrm3qr.png" },
         new Imagene { Id = 52, FileName = "Alitas-en-salsa-BBQ"          , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258869/Alitas-en-salsa-BBQ_itujfe.png" },
         new Imagene { Id = 53, FileName = "Alitas-broaster"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258869/Alitas-broaster_e0wdiv.png" },
         new Imagene { Id = 54, FileName = "Tequenos-especiales"          , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Tequenos-especiales_q4topa.png" },
         new Imagene { Id = 55, FileName = "Durazno-en-almíbar"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Durazno-en-almibar_yfzewe.png" },
         new Imagene { Id = 56, FileName = "Helado-02-bolas"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Helado-02-bolas_n7g79i.png" },
         new Imagene { Id = 57, FileName = "Helado-03-bolas"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Helado-03-bolas_ct5qkk.png" },
         new Imagene { Id = 58, FileName = "Gelatina"                     , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Gelatina_lirwco.png" },
         new Imagene { Id = 59, FileName = "Flan"                         , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Flan_mygmdv.png" },
         new Imagene { Id = 60, FileName = "Jugo-de-papaya"               , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-papaya_miqnbk.png" },
         new Imagene { Id = 61, FileName = "Jugo-de-fresa-con-leche"      , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-fresa_abese7.png" },
         new Imagene { Id = 62, FileName = "Jugo-de-platano"              , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-platano_yrsmee.png" },
         new Imagene { Id = 63, FileName = "Jugo-surtido"                 , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-surtido_fjl9jf.png" },
         new Imagene { Id = 64, FileName = "Ensalada-de-frutas"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Ensalada-de-frutas_jybwbc.png" },
         new Imagene { Id = 65, FileName = "Milkshake-de-Oreo"            , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-oreo_crwp9x.png" },
         new Imagene { Id = 66, FileName = "Milkshake-de-durazno"         , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-durazno_p1ltvm.png" },
         new Imagene { Id = 67, FileName = "Milkshake-de-fresa"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-fresa_btvt9f.png" },
         new Imagene { Id = 68, FileName = "Salchipapa-clasica"           , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258864/Salchipapa-clasica_umbxrb.png" },
         new Imagene { Id = 69, FileName = "Salchipapa-ayacuchana"        , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258864/Salchipapa-ayacuchana_vzk1h3.png" },
         new Imagene { Id = 70, FileName = "Salchipiernita"               , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Salchipiernita_wxckli.png" },
         new Imagene { Id = 71, FileName = "Mounstruo"                    , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258855/Mounstruo_bgqfgs.png" },
         new Imagene { Id = 72, FileName = "Mounstrito"                   , ImageData = "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258854/Mounstrito_vjfxho.png" }
     );
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("insumo_id_pk");

            entity.HasOne(d => d.IdUnidadNavigation).WithMany(p => p.Insumos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unidad_medida_id_fk");
            entity.HasData(
            new Insumo { IdInsumo = 1,  Nombre = "Aceite x Balde",        IdUnidad = 1 }, // Balde
            new Insumo { IdInsumo = 2,  Nombre = "Aceite x Litro",        IdUnidad = 2 }, // Litro
            new Insumo { IdInsumo = 3,  Nombre = "Aceite Sésamo",         IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 4,  Nombre = "Aji",                   IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 5,  Nombre = "Ajicero",               IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 6,  Nombre = "Arroz con leche",       IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 7,  Nombre = "Azucar Blanca",         IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 8,  Nombre = "Azucar Rubia",          IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 9,  Nombre = "Bolsa Basura",          IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 10, Nombre = "Bolsa Cuarto Pollo",    IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 11, Nombre = "Bolsa Ensalada",        IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 12, Nombre = "Bolsa Medio Pollo",     IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 13, Nombre = "Bolsa Pollo Entero",    IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 14, Nombre = "Bolsa Rollo Pollo",     IdUnidad = 6 }, // Rollo
            new Insumo { IdInsumo = 15, Nombre = "Café Sobre",            IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 16, Nombre = "Caja ligas",            IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 17, Nombre = "Carbón",                IdUnidad = 7 }, // Bolsa 5 kg
            new Insumo { IdInsumo = 18, Nombre = "Cebolla",               IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 19, Nombre = "Cebolla China",         IdUnidad = 8 }, // Atado
            new Insumo { IdInsumo = 20, Nombre = "Champiñon lata",        IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 21, Nombre = "Chicha Morada",         IdUnidad = 9 }, // Bolsa
            new Insumo { IdInsumo = 22, Nombre = "Conserva Durazno",      IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 23, Nombre = "Espinaca",              IdUnidad = 8 }, // Atado
            new Insumo { IdInsumo = 24, Nombre = "Fideo Spaguetti",       IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 25, Nombre = "Fósforo",               IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 26, Nombre = "Fresa",                 IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 27, Nombre = "Gas",                   IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 28, Nombre = "Hierba Buena",          IdUnidad = 8 }, // Atado
            new Insumo { IdInsumo = 29, Nombre = "Huevo",                 IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 30, Nombre = "Ketchup",               IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 31, Nombre = "Leche",                 IdUnidad = 2 }, // Litro
            new Insumo { IdInsumo = 32, Nombre = "Leche Evaporada",       IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 33, Nombre = "Leche Fresca",          IdUnidad = 2 }, // Litro
            new Insumo { IdInsumo = 34, Nombre = "Lechuga",               IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 35, Nombre = "Leña",                  IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 36, Nombre = "Limón",                 IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 37, Nombre = "Lonja",                 IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 38, Nombre = "Mates General",         IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 39, Nombre = "Mayonesa",              IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 40, Nombre = "Milo lata",             IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 41, Nombre = "Mondadiente",           IdUnidad = 10}, // Caja
            new Insumo { IdInsumo = 42, Nombre = "Mostaza",               IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 43, Nombre = "Ostión",                IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 44, Nombre = "Pan",                   IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 45, Nombre = "Panetón",               IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 46, Nombre = "Papa",                  IdUnidad = 11}, // Bolsa 20 kg
            new Insumo { IdInsumo = 47, Nombre = "Papaya",                IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 48, Nombre = "Papel Manteca",         IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 49, Nombre = "Pepino",                IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 50, Nombre = "Pimenton",              IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 51, Nombre = "Pisco",                 IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 52, Nombre = "Pollo",                 IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 53, Nombre = "Plátano",               IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 54, Nombre = "Queso molde",           IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 55, Nombre = "Queso Parmesano",       IdUnidad = 3 },// Unidad
            new Insumo { IdInsumo = 56, Nombre = "Refresco Maracuya",     IdUnidad = 9 }, // Bolsa
            new Insumo { IdInsumo = 57, Nombre = "Ron",                   IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 58, Nombre = "Salsa de Tomate",       IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 59, Nombre = "Sillao",                IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 60, Nombre = "Taper 6 u 8 Ensalada",  IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 61, Nombre = "Taper Cuarto Pollo",    IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 62, Nombre = "Taper Ensalada Entero", IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 63, Nombre = "Taper Medio Pollo",     IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 64, Nombre = "Taper Pollo Entero",    IdUnidad = 5 }, // Ciento
            new Insumo { IdInsumo = 65, Nombre = "Tomate",                IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 66, Nombre = "Vaso Plástico Flan",    IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 67, Nombre = "Vaso Plástico Gelatina",IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 68, Nombre = "Vaso Vidrio Flan",      IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 69, Nombre = "Vaso Vidrio Gelatina",  IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 70, Nombre = "Vinagre",               IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 71, Nombre = "Vinagreta",             IdUnidad = 4 }, // Kilo
            new Insumo { IdInsumo = 72, Nombre = "Vino",                  IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 73, Nombre = "Whiski",                IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 74, Nombre = "Yuquitas",              IdUnidad = 3 }, // Unidad
            new Insumo { IdInsumo = 75, Nombre = "Zanahoria",             IdUnidad = 4 } // Kilo
        );
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("inventario_id_pk");

            entity.HasOne(d => d.Sucursal)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_id_fk");

            entity.HasData(
                new Inventario() { IdInventario = 1, IdSucursal = 1, FechaActualizacion = DateTime.Now},
                new Inventario() { IdInventario = 2, IdSucursal = 2, FechaActualizacion = DateTime.Now}
                );
        });


        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("mesa_id_pk");
            entity.HasData(
                new Mesa {IdMesa = 1, Nombre = "Mesa 1", Estado = true },
                new Mesa {IdMesa = 2, Nombre = "Mesa 2", Estado = true },
                new Mesa {IdMesa = 3, Nombre = "Mesa 3", Estado = true },
                new Mesa {IdMesa = 4, Nombre = "Mesa 4", Estado = true },
                new Mesa {IdMesa = 5, Nombre = "Mesa 5", Estado = true },
                new Mesa {IdMesa = 6, Nombre = "Mesa 6", Estado = true },
                new Mesa {IdMesa = 7, Nombre = "Mesa 7", Estado = true },
                new Mesa {IdMesa = 8, Nombre = "Mesa 8", Estado = true },
                new Mesa {IdMesa = 9, Nombre = "Mesa 9", Estado = true }
                );
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("metodo_pago_id_pk");
            entity.Property(e => e.Estado).HasColumnType("bit");

            entity.HasData(
                new MetodoPago { IdMetodo = 1, Descripcion = "Efectivo",     Estado = true },
                new MetodoPago { IdMetodo = 2, Descripcion = "Tarjeta",      Estado = true },
                new MetodoPago { IdMetodo = 3, Descripcion = "Transferencia",Estado = true },
                new MetodoPago { IdMetodo = 4, Descripcion = "Descuento",    Estado = true },
                new MetodoPago { IdMetodo = 5, Descripcion = "Otros",        Estado = true }
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
        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetallePedido).HasName("detalle_pedido_id_pk"); // Primary Key

            entity.HasOne(d => d.Producto)
                  .WithMany(p => p.DetallePedidos)
                  .HasForeignKey(d => d.IdProducto)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("producto_detalle_pedido_fk"); // Foreign Key to Producto

            entity.HasOne(d => d.Pedido)
                  .WithMany(p => p.Detalles)
                  .HasForeignKey(d => d.IdPedido)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("pedido_detalle_pedido_fk"); // Foreign Key to Pedido
        });
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("pedido_id_pk"); // Primary Key

            entity.HasOne(d => d.Mesa)
                  .WithMany(p => p.Pedidos)
                  .HasForeignKey(d => d.IdMesa)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("mesa_pedido_fk"); // Foreign Key to Mesa

            entity.HasMany(d => d.Detalles)
                  .WithOne(p => p.Pedido)
                  .HasForeignKey(d => d.IdPedido)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("pedido_detalle_pedido_fk"); // Foreign Key to DetallePedido

            entity.HasOne(d => d.TipoPedido)
                  .WithMany(p => p.Pedidos)
                  .HasForeignKey(d => d.IdTipoPedido)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("tipo_pedido_pedido_fk"); // Foreign Key to TipoPedido
            entity.HasOne(d => d.Empleado) // Relación con Empleado
                  .WithMany(p => p.Pedidos)
                  .HasForeignKey(d => d.IdEmpleado)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("empleado_pedido_fk");
        });
        modelBuilder.Entity<PedidoLlevar>(entity =>
        {
            entity.HasKey(e => e.IdPedidoLlevar).HasName("pedido_llevar_id_pk"); // Primary Key

            entity.HasOne(d => d.TipoPedido)
                  .WithMany(p => p.PedidosLlevar)
                  .HasForeignKey(d => d.IdTipoPedido)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("tipo_pedido_llevar_fk"); // Foreign Key to TipoPedido

            entity.HasOne(d => d.Empleado)
                  .WithMany(p => p.PedidosLlevar)
                  .HasForeignKey(d => d.IdEmpleado)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("empleado_pedido_llevar_fk"); // Foreign Key to Empleado

            entity.HasOne(d => d.Cliente)
                  .WithMany(p => p.PedidosLlevar)
                  .HasForeignKey(d => d.IdCliente)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("cliente_pedido_llevar_fk"); // Foreign Key to Cliente

            entity.HasMany(d => d.DetallesLlevar)
                  .WithOne(p => p.PedidoLlevar)
                  .HasForeignKey(d => d.IdPedidoLlevar)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("pedido_llevar_detalle_fk"); // Foreign Key to DetallePedidoLlevar
        });
        modelBuilder.Entity<DetallePedidoLlevar>(entity =>
        {
            entity.HasKey(e => e.IdDetallePedidoLlevar).HasName("detalle_pedido_llevar_id_pk"); // Primary Key
                       
            entity.HasOne(d => d.PedidoLlevar)
                  .WithMany(p => p.DetallesLlevar)
                  .HasForeignKey(d => d.IdPedidoLlevar)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("pedido_llevar_detalle_fk"); // Foreign Key to PedidoLlevar

            entity.HasOne(d => d.Producto)
                  .WithMany(p => p.DetallePedidoLlevar)
                  .HasForeignKey(d => d.IdProducto)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("producto_detalle_pedido_llevar_fk"); // Foreign Key to Producto
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

        //modelBuilder.Entity<Produccion>(entity =>
        //{
        //    entity.HasKey(e => e.IdProduccion).HasName("produccion_id_pk");
        //});

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("producto_id_pk");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100);

            entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_categoria_fk");

            entity.HasOne(d => d.IdImgNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("img_id_fk");
            entity.HasData(
    // Hamburguesas
    new Producto { IdProducto =  1, Nombre = "Hamburguesa clásica",           Descripcion = "Hamburguesa clásica",           Derivar = "Horno",  IdCategoria = 17, PrecioVenta =  9.00M, IdImg=1 },
    new Producto { IdProducto =  2, Nombre = "Hamburguesa queso tocino",      Descripcion = "Hamburguesa queso tocino",      Derivar = "Horno",  IdCategoria = 17, PrecioVenta = 12.00M, IdImg=2 },
    new Producto { IdProducto =  3, Nombre = "Hamburguesa señorial",          Descripcion = "Hamburguesa señorial",          Derivar = "Horno",  IdCategoria = 17, PrecioVenta = 15.00M, IdImg=3 },

    // Pollos y Parrillas
    new Producto { IdProducto =  4, Nombre = "1/4 de pollo a la brasa",       Descripcion = "1/4 de pollo a la brasa",       Derivar = "Horno",  IdCategoria = 6, PrecioVenta = 12.00M, IdImg=4 },
    new Producto { IdProducto =  5, Nombre = "1/4 de pollo broaster",         Descripcion = "1/4 de pollo broaster",         Derivar = "Horno",  IdCategoria = 6, PrecioVenta = 15.00M, IdImg=5 },
    new Producto { IdProducto =  6, Nombre = "Parrilla de pollo",             Descripcion = "Parrilla de pollo",             Derivar = "Horno",  IdCategoria = 7, PrecioVenta = 15.00M, IdImg=6 },
    new Producto { IdProducto =  7, Nombre = "Parrilla de pollo al ajo",      Descripcion = "Parrilla de pollo al ajo",      Derivar = "Horno",  IdCategoria = 7, PrecioVenta = 16.00M, IdImg=7 },
    new Producto { IdProducto =  8, Nombre = "Parrilla de pollo dietética",   Descripcion = "Parrilla de pollo dietética",   Derivar = "Horno",  IdCategoria = 7, PrecioVenta = 16.00M, IdImg=8 },
    new Producto { IdProducto =  9, Nombre = "Parrilla mixta",                Descripcion = "Parrilla mixta",                Derivar = "Horno",  IdCategoria = 7, PrecioVenta = 20.00M, IdImg=9 },
    new Producto { IdProducto = 10, Nombre = "Brochetas de pollo",            Descripcion = "Brochetas de pollo",            Derivar = "Horno",  IdCategoria = 8, PrecioVenta = 15.00M, IdImg=10 },
    new Producto { IdProducto = 11, Nombre = "Pollo a la pizzarola",          Descripcion = "Pollo a la pizzarola",          Derivar = "Horno",  IdCategoria = 8, PrecioVenta = 20.00M, IdImg=11 },
    new Producto { IdProducto = 12, Nombre = "Bisteck a la parrilla",         Descripcion = "Bisteck a la parrilla",         Derivar = "Horno",  IdCategoria = 8, PrecioVenta = 18.00M, IdImg=12 },
    new Producto { IdProducto = 13, Nombre = "Chorizo a la parrilla",         Descripcion = "Chorizo a la parrilla",         Derivar = "Horno",  IdCategoria = 8, PrecioVenta = 11.00M, IdImg=13 },

    // Platos de Fondo
    new Producto { IdProducto = 14, Nombre = "Chicharrón señorial",           Descripcion = "Chicharrón señorial",           Derivar = "Horno",  IdCategoria = 9, PrecioVenta = 15.00M, IdImg=14 },
    new Producto { IdProducto = 15, Nombre = "Lonjitas",                      Descripcion = "Lonjitas",                      Derivar = "Horno",  IdCategoria = 9, PrecioVenta =  6.00M, IdImg=15 },
    new Producto { IdProducto = 16, Nombre = "Chaufa especial",               Descripcion = "Chaufa especial",               Derivar = "Cocina", IdCategoria = 9, PrecioVenta = 10.00M, IdImg=16 },
    new Producto { IdProducto = 17, Nombre = "Chaufa mixto",                  Descripcion = "Chaufa mixto",                  Derivar = "Cocina", IdCategoria = 9, PrecioVenta = 12.00M, IdImg=17 },
    new Producto { IdProducto = 18, Nombre = "Spaguetti a lo alfredo",        Descripcion = "Spaguetti a lo alfredo",        Derivar = "Cocina", IdCategoria = 9, PrecioVenta = 14.00M, IdImg=18 },

    // Bebidas Calientes
    new Producto { IdProducto = 19, Nombre = "Café pasado",                   Descripcion = "Café pasado",                   Derivar = "Cocina", IdCategoria = 10, PrecioVenta =  2.50M, IdImg=19 },
    new Producto { IdProducto = 20, Nombre = "Chocolate con panetón",         Descripcion = "Chocolate con panetón",         Derivar = "Cocina", IdCategoria = 10, PrecioVenta =  5.00M, IdImg=20 },
    new Producto { IdProducto = 21, Nombre = "Leche fresca",                  Descripcion = "Leche fresca",                  Derivar = "Cocina", IdCategoria = 10, PrecioVenta =  3.00M, IdImg=21 },
    new Producto { IdProducto = 22, Nombre = "Milo",                          Descripcion = "Milo",                          Derivar = "Cocina", IdCategoria = 10, PrecioVenta =  3.00M, IdImg=22 },
    new Producto { IdProducto = 23, Nombre = "Café con leche",                Descripcion = "Café con leche",                Derivar = "Cocina", IdCategoria = 10, PrecioVenta =  4.00M, IdImg=23 },
    new Producto { IdProducto = 24, Nombre = "Mates",                         Descripcion = "Mates",                         Derivar = "Cocina", IdCategoria = 10, PrecioVenta =  2.00M, IdImg=24 },

    // Bebidas Frías
    new Producto { IdProducto = 25, Nombre = "Gaseosa de 3lts",               Descripcion = "Gaseosa de 3lts",               Derivar = "Cocina", IdCategoria = 11, PrecioVenta = 14.00M, IdImg=25 },
    new Producto { IdProducto = 26, Nombre = "Gaseosa de 2.25lts",            Descripcion = "Gaseosa de 2.25lts",            Derivar = "Cocina", IdCategoria = 11, PrecioVenta = 11.00M, IdImg=26 },
    new Producto { IdProducto = 27, Nombre = "Gaseosa de 1.5lts",             Descripcion = "Gaseosa de 1.5lts",             Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  9.00M, IdImg=27 },
    new Producto { IdProducto = 28, Nombre = "Gaseosa de 1lts",               Descripcion = "Gaseosa de 1lts",               Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  7.00M, IdImg=28 },
    new Producto { IdProducto = 29, Nombre = "Gaseosa de 1/2lt",              Descripcion = "Gaseosa de 1/2lt",              Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  4.00M, IdImg=29 },
    new Producto { IdProducto = 30, Nombre = "Gaseosa personal",              Descripcion = "Gaseosa personal",              Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  2.50M, IdImg=30 },
    new Producto { IdProducto = 31, Nombre = "Gaseosa pirañita",              Descripcion = "Gaseosa pirañita",              Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  1.50M, IdImg=31 },
    new Producto { IdProducto = 32, Nombre = "Refresco de maracuya (Jarra)",  Descripcion = "Refresco de maracuya (Jarra)",  Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  8.00M, IdImg=32 },
    new Producto { IdProducto = 33, Nombre = "Chicha morada (Jarra)",         Descripcion = "Chicha morada (Jarra)",         Derivar = "Cocina", IdCategoria = 11, PrecioVenta =  8.00M, IdImg=33 },
    new Producto { IdProducto = 34, Nombre = "Limonada Frozen (Jarra)",       Descripcion = "Limonada Frozen (Jarra)",       Derivar = "Cocina", IdCategoria = 11, PrecioVenta = 12.00M, IdImg=34 },
    new Producto { IdProducto = 35, Nombre = "Limonada Americana (Jarra)",    Descripcion = "Limonada Americana (Jarra)",    Derivar = "Cocina", IdCategoria = 11, PrecioVenta = 11.00M, IdImg=35 },

    // Licores
    new Producto { IdProducto = 36, Nombre = "Caliente de pisco",             Descripcion = "Caliente de pisco",             Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 30.00M, IdImg=36 },
    new Producto { IdProducto = 37, Nombre = "Caliente de vino",              Descripcion = "Caliente de vino",              Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 40.00M, IdImg=37 },
    new Producto { IdProducto = 38, Nombre = "Caliente de ron",               Descripcion = "Caliente de ron",               Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 35.00M, IdImg=38 },
    new Producto { IdProducto = 39, Nombre = "Caliente de whisky",            Descripcion = "Caliente de whisky",            Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 45.00M, IdImg=39 },
    new Producto { IdProducto = 40, Nombre = "Cerveza en lata",               Descripcion = "Cerveza en lata",               Derivar = "Cocina", IdCategoria = 12, PrecioVenta =  6.00M, IdImg=40 },
    new Producto { IdProducto = 41, Nombre = "Cerveza negra",                 Descripcion = "Cerveza negra",                 Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 10.00M, IdImg=41 },
    new Producto { IdProducto = 42, Nombre = "Cerveza de trigo",              Descripcion = "Cerveza de trigo",              Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 10.00M, IdImg=42 },
    new Producto { IdProducto = 43, Nombre = "Vino queirolo (Vaso)",          Descripcion = "Vino queirolo (Vaso)",          Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 10.00M, IdImg=43 },
    new Producto { IdProducto = 44, Nombre = "Whisky (Vaso)",                 Descripcion = "Whisky (Vaso)",                 Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 10.00M, IdImg=44 },
    new Producto { IdProducto = 45, Nombre = "Pisco Vargas (Vaso)",           Descripcion = "Pisco Vargas (Vaso)",           Derivar = "Cocina", IdCategoria = 12, PrecioVenta = 10.00M, IdImg=45 },

    // Cócteles
    new Producto { IdProducto = 46, Nombre = "Mojito",                        Descripcion = "Mojito",                        Derivar = "Cocina", IdCategoria = 13, PrecioVenta = 15.90M, IdImg=46 },
    new Producto { IdProducto = 47, Nombre = "Machu Picchu",                  Descripcion = "Machu Picchu",                  Derivar = "Cocina", IdCategoria = 13, PrecioVenta = 17.90M, IdImg=47 },
    new Producto { IdProducto = 48, Nombre = "Daikiri",                       Descripcion = "Daikiri",                       Derivar = "Cocina", IdCategoria = 13, PrecioVenta = 15.90M, IdImg=48 },
    new Producto { IdProducto = 49, Nombre = "Piña colada",                   Descripcion = "Piña colada",                   Derivar = "Cocina", IdCategoria = 13, PrecioVenta = 16.90M, IdImg=49 },
    new Producto { IdProducto = 50, Nombre = "Pisco sour",                    Descripcion = "Pisco sour",                    Derivar = "Cocina", IdCategoria = 13, PrecioVenta = 15.90M, IdImg=50 },
    new Producto { IdProducto = 51, Nombre = "Naranjita",                     Descripcion = "Naranjita",                     Derivar = "Cocina", IdCategoria = 13, PrecioVenta = 15.00M, IdImg=51 },

    // Piqueos de la Casa
    new Producto { IdProducto = 52, Nombre = "Alitas en salsa BBQ",           Descripcion = "Alitas en salsa BBQ",           Derivar = "Horno",  IdCategoria = 14, PrecioVenta = 35.00M, IdImg=52 },
    new Producto { IdProducto = 53, Nombre = "Alitas broaster",               Descripcion = "Alitas broaster",               Derivar = "Horno",  IdCategoria = 14, PrecioVenta = 35.00M, IdImg=53 },
    new Producto { IdProducto = 54, Nombre = "Tequeños especiales",           Descripcion = "Tequeños especiales",           Derivar = "Cocina", IdCategoria = 14, PrecioVenta = 20.00M, IdImg=54 },

    // Postres
    new Producto { IdProducto = 55, Nombre = "Durazno en almíbar",            Descripcion = "Durazno en almíbar",            Derivar = "Cocina", IdCategoria = 15, PrecioVenta =  5.00M, IdImg=55 },
    new Producto { IdProducto = 56, Nombre = "Helado 02 bolas",               Descripcion = "Helado 02 bolas",               Derivar = "Cocina", IdCategoria = 15, PrecioVenta =  4.00M, IdImg=56 },
    new Producto { IdProducto = 57, Nombre = "Helado 03 bolas",               Descripcion = "Helado 03 bolas",               Derivar = "Cocina", IdCategoria = 15, PrecioVenta =  6.00M, IdImg=57 },
    new Producto { IdProducto = 58, Nombre = "Gelatina",                      Descripcion = "Gelatina",                      Derivar = "Cocina", IdCategoria = 15, PrecioVenta =  3.00M, IdImg=58 },
    new Producto { IdProducto = 59, Nombre = "Flan",                          Descripcion = "Flan",                          Derivar = "Cocina", IdCategoria = 15, PrecioVenta =  5.00M, IdImg=59 },

    // Jugos y Milkshakes
    new Producto { IdProducto = 60, Nombre = "Jugo de papaya",                Descripcion = "Jugo de papaya",                Derivar = "Cocina", IdCategoria = 16, PrecioVenta =  5.00M, IdImg=60 },
    new Producto { IdProducto = 61, Nombre = "Jugo de fresa con leche",       Descripcion = "Jugo de fresa con leche",       Derivar = "Cocina", IdCategoria = 16, PrecioVenta =  8.00M, IdImg=61 },
    new Producto { IdProducto = 62, Nombre = "Jugo de plátano",               Descripcion = "Jugo de plátano",               Derivar = "Cocina", IdCategoria = 16, PrecioVenta =  5.00M, IdImg=62 },
    new Producto { IdProducto = 63, Nombre = "Jugo surtido",                  Descripcion = "Jugo surtido",                  Derivar = "Cocina", IdCategoria = 16, PrecioVenta =  5.00M, IdImg=63 },
    new Producto { IdProducto = 64, Nombre = "Ensalada de frutas",            Descripcion = "Ensalada de frutas",            Derivar = "Cocina", IdCategoria = 16, PrecioVenta =  7.00M, IdImg=64 },
    new Producto { IdProducto = 65, Nombre = "Milkshake de Oreo",             Descripcion = "Milkshake de Oreo",             Derivar = "Cocina", IdCategoria = 16, PrecioVenta = 11.90M, IdImg=65 },
    new Producto { IdProducto = 66, Nombre = "Milkshake de durazno",          Descripcion = "Milkshake de durazno",          Derivar = "Cocina", IdCategoria = 16, PrecioVenta = 11.90M, IdImg=66 },
    new Producto { IdProducto = 67, Nombre = "Milkshake de fresa",            Descripcion = "Milkshake de fresa",            Derivar = "Cocina", IdCategoria = 16, PrecioVenta = 11.90M, IdImg=67 },

    // Comida Rápida
    new Producto { IdProducto = 68, Nombre = "Salchipapa clásica",            Descripcion = "Salchipapa clásica",            Derivar = "Horno",  IdCategoria = 9, PrecioVenta =  7.00M, IdImg=68 },
    new Producto { IdProducto = 69, Nombre = "Salchipapa ayacuchana",         Descripcion = "Salchipapa ayacuchana",         Derivar = "Horno",  IdCategoria = 9, PrecioVenta =  9.00M, IdImg=69 },
    new Producto { IdProducto = 70, Nombre = "Salchipiernita",                Descripcion = "Salchipiernita",                Derivar = "Horno",  IdCategoria = 9, PrecioVenta = 11.00M, IdImg=70 },
    new Producto { IdProducto = 71, Nombre = "Mounstruo",                     Descripcion = "Mounstruo",                     Derivar = "Cocina", IdCategoria = 9, PrecioVenta = 18.00M, IdImg=71 },
    new Producto { IdProducto = 72, Nombre = "Mounstrito",                    Descripcion = "Mounstrito",                    Derivar = "Cocina", IdCategoria = 9, PrecioVenta = 10.00M, IdImg=72 }
);

        });

        modelBuilder.Entity<ProductoSucursal>(entity =>
        {
            entity.HasKey(e => e.IdProductoSucursal).HasName("producto_sucursal_id_pk");

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany(p => p.ProductoSucursals)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorias_id_fk");

            entity.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.ProductoSucursals)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_id_fk");

            entity.HasOne(d => d.IdSucursalNavigation)
                .WithMany(p => p.ProductoSucursals)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursales_id_fk");

            entity.HasOne(d => d.IdUnidadNavigation)
                .WithMany(p => p.ProductoSucursals)
                .HasForeignKey(d => d.IdUnidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unidad_medida_id_fk");

            entity.HasMany(d => d.DetalleVenta)
                .WithOne(p => p.ProductoSucursal)
                .HasForeignKey(d => d.IdProductoSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_sucursal_id_fk");
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
           new Role { IdRol = 3, Nombre = "Cajero",        Estado = "Activo" }, 
           new Role { IdRol = 4, Nombre = "Mozo",          Estado = "Activo" }, 
           new Role { IdRol = 5, Nombre = "Cliente",       Estado = "Activo" } 
       );
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => e.IdSalida).HasName("salida_id_pk");

            entity.HasOne(d => d.Inventario)
                .WithMany(p => p.Salidas)
                .HasForeignKey(d => d.IdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_id_salida_fk");

           entity.HasOne(d => d.IdNavigationInsumo)
                .WithMany(p => p.Salida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("salida_insumo_fk");
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
            new TipoPedido { IdTipoPedido = 1, Descripcion = "Indoor" },
            new TipoPedido { IdTipoPedido = 2, Descripcion = "PickUp" });
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdTipoTransaccion).HasName("tipo_transaccion_id_pk");
        });


        modelBuilder.Entity<UnidadMedicion>(entity =>
        {
            entity.HasKey(e => e.IdUnidad).HasName("unidad_medicion_id_pk");
            entity.HasData(
        new UnidadMedicion { IdUnidad =  1,  Abreviacion = "Balde",   Descripcion = "Balde" },
        new UnidadMedicion { IdUnidad =  2,  Abreviacion = "Lt",      Descripcion = "Litro" },
        new UnidadMedicion { IdUnidad =  3,  Abreviacion = "Und",     Descripcion = "Unidad" },
        new UnidadMedicion { IdUnidad =  4,  Abreviacion = "Kg",      Descripcion = "Kilo" },
        new UnidadMedicion { IdUnidad =  5,  Abreviacion = "Cto",     Descripcion = "Ciento" },
        new UnidadMedicion { IdUnidad =  6,  Abreviacion = "Rllo",    Descripcion = "Rollo" },
        new UnidadMedicion { IdUnidad =  7,  Abreviacion = "B-5Kg",   Descripcion = "Bolsa 5 kg" },
        new UnidadMedicion { IdUnidad =  8,  Abreviacion = "At",      Descripcion = "Atado" },
        new UnidadMedicion { IdUnidad =  9,  Abreviacion = "Bsa",     Descripcion = "Bolsa" },
        new UnidadMedicion { IdUnidad = 10,  Abreviacion = "Cja",     Descripcion = "Caja" },
        new UnidadMedicion { IdUnidad = 11,  Abreviacion = "B-20Kg",  Descripcion = "Bolsa 20 kg" }
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
                UserName = "admin",
                IdImg = 1,
            }
        );
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("venta_id_pk"); // Definir Primary Key
            entity.HasOne(d => d.IdAperturaNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdApertura)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("apertura_caja_id_fk"); // Relación con AperturaCaja

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdCliente)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("cliente_id_fk"); // Relación con Cliente

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdComprobante)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("comprobante_id_fk"); // Relación con TipoComprobante

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdEmpleado)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("empleado_id_fk"); // Relación con Empleado

            entity.HasOne(d => d.IdMetodoNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdMetodo)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("metodo_id_fk"); // Relación con MetodoPago

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdSucursal)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("sucursales_ventas_id_fk"); // Relación con Sucursal

            entity.HasOne(d => d.IdTipoPedidoNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdTipoPedido)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("tipo_pedido_id_fk"); // Relación con TipoPedido

            entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.Venta)
                  .HasForeignKey(d => d.IdVoucher)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("voucher_id_fk"); // Relación con Voucher

            entity.HasMany(e => e.DetalleVenta)
                  .WithOne(e => e.Venta)
                  .HasForeignKey(e => e.IdVenta)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("venta_detalle_venta_fk"); // Relación con DetalleVenta
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("detalle_venta_id_pk"); // Primary Key

            entity.HasOne(d => d.Producto)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_detalle_venta_fk"); // Foreign Key to Producto

            entity.HasOne(d => d.Venta)
                .WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("venta_detalle_venta_fk"); // Foreign Key to Venta

            entity.HasOne(d => d.ProductoSucursal)
                .WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProductoSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_sucursal_detalle_venta_fk"); // Foreign Key to ProductoSucursal
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
