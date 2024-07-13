using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("productos", Schema = "Ventas")]
public partial class Producto
{
    [Key]
    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [Column("derivar")]
    [StringLength(100)]
    public string Derivar { get; set; } = null!;
    [Column("precio", TypeName = "decimal(10, 2)")]
    public decimal? PrecioVenta { get; set; }

    [Column("id_img")]
    public int? IdImg { get; set; }
    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("Productos")]
    public virtual Categoria Categoria { get; set; } = null!;

    [ForeignKey("IdImg")]
    [InverseProperty("Productos")]
    public virtual Imagene IdImgNavigation { get; set; } = null!;

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; } = new List<ProductoSucursal>();
}
