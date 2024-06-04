using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("tipo_estado", Schema = "Generico")]
public partial class TipoEstado
{
    [Key]
    [Column("id_tipo_estado")]
    public int IdTipoEstado { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [InverseProperty("IdTipoEstadoNavigation")]
    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();
}
