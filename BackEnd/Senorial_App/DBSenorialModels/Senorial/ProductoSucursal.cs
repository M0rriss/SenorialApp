using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("producto_sucursal", Schema = "Ventas")]
public partial class ProductoSucursal
{
    [Key]
    [Column("id_producto_sucursal")]
    public int IdProductoSucursal { get; set; }

    [Column("id_unidad")]
    public int IdUnidad { get; set; }

    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("precio", TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [InverseProperty("ProductoSucursal")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("ProductoSucursals")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("ProductoSucursals")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("ProductoSucursals")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [ForeignKey("IdUnidad")]
    [InverseProperty("ProductoSucursals")]
    public virtual UnidadMedicion IdUnidadNavigation { get; set; } = null!;

}
