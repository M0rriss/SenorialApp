using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("tipo_documentos", Schema = "Usuarios")]
[Index("Descripcion", Name = "tipo_documento_descripcion_uk", IsUnique = true)]
public partial class TipoDocumento
{
    [Key]
    [Column("id_tipo_doc")]
    public int IdTipoDoc { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [Column("abreviacion")]
    [StringLength(100)]
    public string? Abreviacion { get; set; }

    [InverseProperty("IdTipoDocNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
