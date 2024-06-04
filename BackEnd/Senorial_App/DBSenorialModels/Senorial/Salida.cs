using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[PrimaryKey("IdDetInventario", "IdProduccion", "IdSucursal")]
[Table("salidas", Schema = "Produccion")]
public partial class Salida
{
    [Key]
    [Column("id_det_inventario")]
    public int IdDetInventario { get; set; }

    [Key]
    [Column("id_produccion")]
    public int IdProduccion { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Key]
    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [ForeignKey("IdDetInventario")]
    [InverseProperty("Salida")]
    public virtual DetalleInventario IdDetInventarioNavigation { get; set; } = null!;

    [ForeignKey("IdProduccion")]
    [InverseProperty("Salida")]
    public virtual Produccion IdProduccionNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("Salida")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
