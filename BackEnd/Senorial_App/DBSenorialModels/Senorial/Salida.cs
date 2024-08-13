using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;


[Table("Salida", Schema = "Almacen")]
public class Salida
{
    [Key]
    [Column("id_salida")]
    public int IdSalida { get; set; }

    [Column("id_inventario")]
    public int IdInventario { get; set; }

    [Column("id_insumo")]
    public int IdInsumo { get; set; }

    [Column("fecha_salida", TypeName = "datetime")]
    public DateTime FechaSalida { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("motivo")]
    [StringLength(250)]
    public string Motivo { get; set; } = null!;

    [ForeignKey("IdInventario")]
    public virtual Inventario Inventario { get; set; } = null!;

    [ForeignKey("IdInventario")]
    [InverseProperty("Salida")]
    public virtual Insumo IdNavigationInsumo { get; set; } = null!;
}