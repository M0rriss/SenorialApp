using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("ventas", Schema = "Ventas")]
[Index("NroDocumento", Name = "ventas_numero_documento_uk", IsUnique = true)]
[Index("NroSerie", Name = "ventas_numero_serie_uk", IsUnique = true)]
public partial class Venta
{
    [Key]
    [Column("id_venta")]
    public int IdVenta { get; set; }

    [Column("fecha_venta", TypeName = "datetime")]
    public DateTime? FechaVenta { get; set; }

    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("id_estado")]
    public int IdEstado { get; set; }

    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("id_mesa_detalle")]
    public int IdMesaDetalle { get; set; }

    [Column("nro_serie")]
    [StringLength(50)]
    public string? NroSerie { get; set; }

    [Column("nro_documento")]
    [StringLength(50)]
    public string? NroDocumento { get; set; }

    [Column("observacion")]
    [StringLength(100)]
    public string? Observacion { get; set; }

    [Column("igv", TypeName = "decimal(10, 2)")]
    public decimal? Igv { get; set; }

    [Column("sub_monto", TypeName = "decimal(10, 2)")]
    public decimal? SubMonto { get; set; }

    [Column("monto_total", TypeName = "decimal(10, 2)")]
    public decimal? MontoTotal { get; set; }

    [Column("id_metodo")]
    public int IdMetodo { get; set; }

    [Column("id_comprobante")]
    public int IdComprobante { get; set; }

    [Column("id_tipo_pedido")]
    public int IdTipoPedido { get; set; }

    [Column("id_voucher")]
    public int IdVoucher { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Venta")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdComprobante")]
    [InverseProperty("Venta")]
    public virtual TipoComprobante IdComprobanteNavigation { get; set; } = null!;

    [ForeignKey("IdEmpleado")]
    [InverseProperty("Venta")]
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    [ForeignKey("IdEstado")]
    [InverseProperty("Venta")]
    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    [ForeignKey("IdMesaDetalle")]
    [InverseProperty("Venta")]
    public virtual DetalleMesa IdMesaDetalleNavigation { get; set; } = null!;

    [ForeignKey("IdMetodo")]
    [InverseProperty("Venta")]
    public virtual MetodoPago IdMetodoNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("Venta")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [ForeignKey("IdTipoPedido")]
    [InverseProperty("Venta")]
    public virtual TipoPedido IdTipoPedidoNavigation { get; set; } = null!;

    [ForeignKey("IdVoucher")]
    [InverseProperty("Venta")]
    public virtual Voucher IdVoucherNavigation { get; set; } = null!;
}
