using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("persona_natural", Schema = "Usuarios")]
public partial class PersonaNatural
{
    [Column("primer_nombre")]
    [StringLength(100)]
    public string? PrimerNombre { get; set; }

    [Column("segundo_nombre")]
    [StringLength(100)]
    public string? SegundoNombre { get; set; }

    [Column("apellido_paterno")]
    [StringLength(100)]
    public string? ApellidoPaterno { get; set; }

    [Column("apellido_materno")]
    [StringLength(100)]
    public string? ApellidoMaterno { get; set; }

    [Key]
    [Column("id_persona")]
    public int IdPersona { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaNatural")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
