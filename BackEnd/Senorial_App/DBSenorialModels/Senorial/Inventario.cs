using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("inventario", Schema = "Almacen")]
public partial class Inventario
{
    [Key]
    [Column("id_inventario")]
    public int IdInventario { get; set; }

    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [InverseProperty("IdInventarioNavigation")]
    public virtual ICollection<DetalleInventario> DetalleInventarios { get; set; } = new List<DetalleInventario>();

    [InverseProperty("IdInventarioNavigation")]
    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    [ForeignKey("IdSucursal")]
    [InverseProperty("Inventarios")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
