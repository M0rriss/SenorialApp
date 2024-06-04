using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("voucher", Schema = "Ventas")]
public partial class Voucher
{
    [Key]
    [Column("id_voucher")]
    public int IdVoucher { get; set; }

    [Column("fecha_emision")]
    [StringLength(50)]
    public string? FechaEmision { get; set; }

    [Column("cantidad")]
    [StringLength(50)]
    public string? Cantidad { get; set; }

    [Column("precio_unitario")]
    [StringLength(50)]
    public string? PrecioUnitario { get; set; }

    [Column("igv")]
    [StringLength(50)]
    public string? Igv { get; set; }

    [Column("importe_total")]
    [StringLength(50)]
    public string? ImporteTotal { get; set; }

    [Column("id_estado")]
    public int IdEstado { get; set; }

    [Column("id_tipo_transaccion")]
    public int IdTipoTransaccion { get; set; }

    [InverseProperty("IdVoucherNavigation")]
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    [ForeignKey("IdEstado")]
    [InverseProperty("Vouchers")]
    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    [ForeignKey("IdTipoTransaccion")]
    [InverseProperty("Vouchers")]
    public virtual TipoTransaccion IdTipoTransaccionNavigation { get; set; } = null!;

    [InverseProperty("IdVoucherNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
