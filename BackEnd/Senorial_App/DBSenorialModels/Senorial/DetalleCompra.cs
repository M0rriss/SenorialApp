using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[PrimaryKey("IdCompra", "IdInsumo")]
[Table("detalle_compra", Schema = "Almacen")]
public partial class DetalleCompra
{
    [Key]
    [Column("id_compra")]
    public int IdCompra { get; set; }

    [Key]
    [Column("id_insumo")]
    public int IdInsumo { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Column("precio_compra", TypeName = "decimal(10, 2)")]
    public decimal? PrecioCompra { get; set; }

    [Column("fecha_expiracion", TypeName = "datetime")]
    public DateTime? FechaExpiracion { get; set; }

    [ForeignKey("IdCompra")]
    [InverseProperty("DetalleCompras")]
    public virtual Compra IdCompraNavigation { get; set; } = null!;

    [ForeignKey("IdInsumo")]
    [InverseProperty("DetalleCompras")]
    public virtual Insumo IdInsumoNavigation { get; set; } = null!;
}
