using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("unidad_medicion", Schema = "Generico")]
public partial class UnidadMedicion
{
    [Key]
    [Column("id_unidad")]
    public int IdUnidad { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    public string? Descripcion { get; set; }

    [Column("abreviacion")]
    [StringLength(50)]
    public string? Abreviacion { get; set; }

    [InverseProperty("IdUnidadNavigation")]
    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    [InverseProperty("IdUnidadNavigation")]
    public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; } = new List<ProductoSucursal>();
}
