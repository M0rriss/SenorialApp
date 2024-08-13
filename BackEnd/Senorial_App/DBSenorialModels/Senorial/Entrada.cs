using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

//[PrimaryKey("IdInventario", "IdCompra")]
[Table("Entrada", Schema = "Almacen")]
public class Entrada
{
    [Key]
    [Column("id_entrada")]
    public int IdEntrada { get; set; }

    [Column("id_inventario")]
    public int IdInventario { get; set; }

    [Column("id_Insumo")]
    public int IdInsumo { get; set; }

    [Column("fecha_ingreso", TypeName = "datetime")]
    public DateTime FechaIngreso { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_compra", TypeName = "decimal(10, 2)")]
    public decimal PrecioCompra { get; set; }


    [ForeignKey("IdInventario")]
    public virtual Inventario Inventario { get; set; } = null!;

    [ForeignKey("IdInsumo")]
    [InverseProperty("Entrada")]
    public virtual Insumo IdNavigationInsumo { get; set; } = null!;
}
