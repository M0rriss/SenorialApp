using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("generos", Schema = "Usuarios")]
[Index("Descripcion", Name = "generos_descripcion_uk", IsUnique = true)]
public partial class Genero
{
    [Key]
    [Column("id_genero")]
    public int IdGenero { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    public string? Descripcion { get; set; }

    [Column("abreviatura")]
    [StringLength(50)]
    public string? Abreviatura { get; set; }

    [InverseProperty("IdGeneroNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
