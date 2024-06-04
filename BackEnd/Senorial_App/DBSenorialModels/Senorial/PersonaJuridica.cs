using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("persona_juridicas", Schema = "Usuarios")]
public partial class PersonaJuridica
{
    [Column("razon_social")]
    [StringLength(100)]
    public string? RazonSocial { get; set; }

    [Column("nombre_comercial")]
    [StringLength(100)]
    public string? NombreComercial { get; set; }

    [Key]
    [Column("id_persona")]
    public int IdPersona { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaJuridica")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
