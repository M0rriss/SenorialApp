using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[PrimaryKey("IdInventario", "IdCompra")]
[Table("entradas", Schema = "Almacen")]
public partial class Entrada
{
    [Key]
    [Column("id_inventario")]
    public int IdInventario { get; set; }

    [Key]
    [Column("id_compra")]
    public int IdCompra { get; set; }

    [Column("fecha_Ingreso", TypeName = "datetime")]
    public DateTime? FechaIngreso { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [ForeignKey("IdCompra")]
    [InverseProperty("Entrada")]
    public virtual Compra IdCompraNavigation { get; set; } = null!;

    [ForeignKey("IdInventario")]
    [InverseProperty("Entrada")]
    public virtual Inventario IdInventarioNavigation { get; set; } = null!;
}
