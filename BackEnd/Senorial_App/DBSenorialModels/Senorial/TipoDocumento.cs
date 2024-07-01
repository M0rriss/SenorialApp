using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("tipo_documento", Schema = "Usuarios")]
public partial class TipoDocumento
{
    [Key]
    [Column("id_tipo_documento")]
    public int IdTipoDocumento { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [InverseProperty("IdTipoDocumentoNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
