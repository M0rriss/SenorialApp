using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("detalle_ventas", Schema = "Ventas")]
public partial class DetalleVenta
{
    [Key]
    [Column("id_det_venta")]
    public int IdDetVenta { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Column("precio_unitario", TypeName = "decimal(10, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [Column("id_venta")]
    public int IdVenta { get; set; }

    [Column("id_producto_sucursal")]
    public int IdProductoSucursal { get; set; }

    [ForeignKey("IdProductoSucursal")]
    [InverseProperty("DetalleVenta")]
    public virtual ProductoSucursal IdProductoSucursalNavigation { get; set; } = null!;

    [ForeignKey("IdVenta")]
    [InverseProperty("DetalleVenta")]
    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
