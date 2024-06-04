using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("compra", Schema = "Almacen")]
public partial class Compra
{
    [Key]
    [Column("id_compra")]
    public int IdCompra { get; set; }

    [Column("id_proveedor")]
    public int IdProveedor { get; set; }

    [Column("id_voucher")]
    public int IdVoucher { get; set; }

    [InverseProperty("IdCompraNavigation")]
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    [InverseProperty("IdCompraNavigation")]
    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    [ForeignKey("IdProveedor")]
    [InverseProperty("Compras")]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    [ForeignKey("IdVoucher")]
    [InverseProperty("Compras")]
    public virtual Voucher IdVoucherNavigation { get; set; } = null!;
}
