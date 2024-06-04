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

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleDashMenu> DetalleDashMenus { get; set; }

    public virtual DbSet<DetalleInventario> DetalleInventarios { get; set; }

    public virtual DbSet<DetalleMesa> DetalleMesas { get; set; }

    public virtual DbSet<DetalleProduccion> DetalleProduccions { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<MenuDash> MenuDashes { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaJuridica> PersonaJuridicas { get; set; }

    public virtual DbSet<PersonaNatural> PersonaNaturals { get; set; }

    public virtual DbSet<Produccion> Produccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoSucursal> ProductoSucursals { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salida> Salidas { get; set; }

    public virtual DbSet<SubCategoria> SubCategorias { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<SucursalUsuario> SucursalUsuarios { get; set; }

    public virtual DbSet<TipoComprobante> TipoComprobantes { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoEstado> TipoEstados { get; set; }

    public virtual DbSet<TipoPedido> TipoPedidos { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }

    public virtual DbSet<UnidadMedicion> UnidadMedicions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder = configurationBuilder.AddJsonFile("appsettings.json");
        IConfiguration configurationFile = configurationBuilder.Build();

        optionsBuilder.EnableSensitiveDataLogging();
        string connection = configurationFile.GetConnectionString("DBSenorial");
        optionsBuilder.UseSqlServer(connection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ambiente>(entity =>
        {
            entity.HasKey(e => e.IdAmbiente).HasName("ambiente_id_pk");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("categoria_id_pk");
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

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.DetalleInventarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estado_id_fk");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleInventarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("det_insumo_id_fk");

            entity.HasOne(d => d.IdInventarioNavigation).WithMany(p => p.DetalleInventarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_id_fk");
        });

        modelBuilder.Entity<DetalleMesa>(entity =>
        {
            entity.HasKey(e => e.IdMesaDetalle).HasName("detalle_mesa_id_pk");

            entity.HasOne(d => d.IdAmbienteNavigation).WithMany(p => p.DetalleMesas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ambiente_id_fk");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.DetalleMesas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mesa_id_fk");
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

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.IdError).HasName("error_id_pk");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Errors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_id_fk");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("estado_id_pk");

            entity.HasOne(d => d.IdTipoEstadoNavigation).WithMany(p => p.Estados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_estado_id_fk");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("genero_id_pk");
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
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("persona_id_pk");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("genero_id_fk");

            entity.HasOne(d => d.IdTipoDocNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_doc_id_fk");
        });

        modelBuilder.Entity<PersonaJuridica>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("persona_juridica_id_pk");

            entity.Property(e => e.IdPersona).ValueGeneratedNever();

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.PersonaJuridica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persona_id_fk");
        });

        modelBuilder.Entity<PersonaNatural>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("persona_natural_id_pk");

            entity.Property(e => e.IdPersona).ValueGeneratedNever();

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.PersonaNatural)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personas_id_fk");
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

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoSucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_id_fk");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.ProductoSucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sub_categorias_id_fk");

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

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Roles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estado_id_fk");
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

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.IdSubCategoria).HasName("sub_categoria_id_pk");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.SubCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sub_categorias_id_fk");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("sucursal_id_pk");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Sucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documento_id_fk");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Sucursals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ubigeo_id_fk");
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

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDoc).HasName("tipo_documento_id_pk");
        });

        modelBuilder.Entity<TipoEstado>(entity =>
        {
            entity.HasKey(e => e.IdTipoEstado).HasName("tipo_estado_id_pk");
        });

        modelBuilder.Entity<TipoPedido>(entity =>
        {
            entity.HasKey(e => e.IdTipoPedido).HasName("tipo_pedido_id_pk");
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdTipoTransaccion).HasName("tipo_transaccion_id_pk");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.IdUbigeo).HasName("ubigeo_id_pk");
        });

        modelBuilder.Entity<UnidadMedicion>(entity =>
        {
            entity.HasKey(e => e.IdUnidad).HasName("unidad_medicion_id_pk");
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
                .HasConstraintName("personas_usuario_id_fk");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roles_id_fk");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("venta_id_pk");

            entity.Property(e => e.FechaVenta).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cliente_id_fk");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comprobante_id_fk");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_id_fk");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estado_id_fk");

            entity.HasOne(d => d.IdMesaDetalleNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mesa_detalle_id_fk");

            entity.HasOne(d => d.IdMetodoNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("metodo_id_fk");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursales_ventas_id_fk");

            entity.HasOne(d => d.IdTipoPedidoNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_pedido_id_fk");

            entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("voucher_id_fk");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.IdVoucher).HasName("voucher_id_pk");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Vouchers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estados_id_fk");

            entity.HasOne(d => d.IdTipoTransaccionNavigation).WithMany(p => p.Vouchers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipo_transaccion_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
