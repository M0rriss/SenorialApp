using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("ventas", Schema = "Ventas")]
[Index("NroDocumento", Name = "ventas_numero_documento_uk", IsUnique = true)]
[Index("NroSerie", Name = "ventas_numero_serie_uk", IsUnique = true)]
public class Venta
{
    [Key]
    [Column("id_venta")]
    public int IdVenta { get; set; } // Primary Key

    [Column("id_apertura")]
    public int IdApertura { get; set; } // Foreign Key hacia AperturaCaja

    [Column("id_cliente")]
    public int IdCliente { get; set; } // Foreign Key hacia Cliente

    [Column("id_empleado")]
    public int IdEmpleado { get; set; } // Foreign Key hacia Empleado

    [Column("id_comprobante")]
    public int IdComprobante { get; set; } // Foreign Key hacia TipoComprobante

    [Column("id_voucher")]
    public int IdVoucher { get; set; } // Foreign Key hacia Voucher

    [Column("id_sucursal")]
    public int IdSucursal { get; set; } // Foreign Key hacia Sucursal

    [Column("estado")]
    [StringLength(100)]
    public bool? Estado { get; set; } // Estado de la venta

    [Column("id_metodo")]
    public int IdMetodo { get; set; } // Foreign Key hacia MetodoPago

    [Column("nro_documento")]
    [StringLength(50)]
    public string? NroDocumento { get; set; } // Número de documento

    [Column("nro_serie")]
    [StringLength(50)]
    public string? NroSerie { get; set; } // Número de serie

    [Column("id_tipo_pedido")]
    public int IdTipoPedido { get; set; } // Foreign Key hacia TipoPedido

    [Column("fecha_venta", TypeName = "datetime")]
    public DateTime? FechaVenta { get; set; } // Fecha de la venta

    [Column("costo_base", TypeName = "decimal(10, 2)")]
    public decimal? CostoBase { get; set; } // Costo base

    [Column("igv", TypeName = "decimal(10, 2)")]
    public decimal? Igv { get; set; } // IGV

    [Column("monto_total", TypeName = "decimal(10, 2)")]
    public decimal? MontoTotal { get; set; } // Monto total

    [Column("vuelto", TypeName = "decimal(10, 2)")]
    public decimal? Vuelto { get; set; } // Vuelto

    [Column("observacion")]
    [StringLength(100)]
    public string? Observacion { get; set; } // Observaciones

    [InverseProperty("Venta")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>(); // Relación con DetalleVenta

    [ForeignKey("IdApertura")]
    [InverseProperty("Venta")]
    public virtual AperturaCaja IdAperturaNavigation { get; set; } = null!; // Relación con AperturaCaja

    [ForeignKey("IdCliente")]
    [InverseProperty("Venta")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!; // Relación con Cliente

    [ForeignKey("IdComprobante")]
    [InverseProperty("Venta")]
    public virtual TipoComprobante IdComprobanteNavigation { get; set; } = null!; // Relación con TipoComprobante

    [ForeignKey("IdEmpleado")]
    [InverseProperty("Venta")]
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!; // Relación con Empleado

    [ForeignKey("IdMetodo")]
    [InverseProperty("Venta")]
    public virtual MetodoPago IdMetodoNavigation { get; set; } = null!; // Relación con MetodoPago

    [ForeignKey("IdSucursal")]
    [InverseProperty("Venta")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!; // Relación con Sucursal

    [ForeignKey("IdTipoPedido")]
    [InverseProperty("Venta")]
    public virtual TipoPedido IdTipoPedidoNavigation { get; set; } = null!; // Relación con TipoPedido

    [ForeignKey("IdVoucher")]
    [InverseProperty("Venta")]
    public virtual Voucher IdVoucherNavigation { get; set; } = null!; // Relación con Voucher
}