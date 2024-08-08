using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("detalle_venta", Schema = "Ventas")]
public partial class DetalleVenta
{
    [Key]
    [Column("id_detalle_venta")]
    public int IdDetalleVenta { get; set; }
    [Column("id_producto_sucursal")]
    public int IdProductoSucursal { get; set; }

    [Column("id_venta")]
    public int IdVenta { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_unitario", TypeName = "decimal(10, 2)")]
    public decimal PrecioUnitario { get; set; }

    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; }

    [ForeignKey("IdProducto")]
    public virtual Producto Producto { get; set; }
    [ForeignKey("IdProductoSucursal")]
    public virtual ProductoSucursal ProductoSucursal { get; set; }

}

