using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("insumo", Schema = "Almacen")]
public partial class Insumo
{
    [Key]
    [Column("id_insumo")]
    public int IdInsumo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("id_unidad")]
    public int IdUnidad { get; set; }

    [ForeignKey("IdUnidad")]
    [InverseProperty("Insumos")]
    public virtual UnidadMedicion IdUnidadNavigation { get; set; } = null!;

    [InverseProperty("Insumo")]
    public virtual ICollection<DetalleInventario> DetalleInventarios { get; set; } = new List<DetalleInventario>();

    [InverseProperty("IdNavigationInsumo")]
    public virtual ICollection<Entrada> Entrada { get; set; } = [];

    [InverseProperty("IdNavigationInsumo")]
    public virtual ICollection<Salida> Salida { get; set; } = [];
}