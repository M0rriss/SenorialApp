using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("personas", Schema = "Usuarios")]
[Index("Correo", Name = "personas_email_uk", IsUnique = true)]
[Index("NroDocumento", Name = "personas_numero_documento_uk", IsUnique = true)]
[Index("Telefono", Name = "personas_phone_uk", IsUnique = true)]
public partial class Persona
{
    [Key]
    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("nro_Documento")]
    [StringLength(12)]
    public string? NroDocumento { get; set; }

    [Column("correo")]
    [StringLength(50)]
    public string? Correo { get; set; }

    [Column("telefono")]
    [StringLength(12)]
    public string? Telefono { get; set; }

    [Column("direccion")]
    [StringLength(100)]
    public string? Direccion { get; set; }

    [Column("tipo_documento")]
    [StringLength(100)]
    public string TipoDocumento { get; set; } = null!;

    [Column("genero")]
    [StringLength(20)]
    public string Genero { get; set; } = null!;

    [Column("tipo_persona")]
    [StringLength(50)]
    public string? TipoPersona { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("IdPersonaNavigation")]
    public virtual PersonaJuridica? PersonaJuridica { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual PersonaNatural? PersonaNatural { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
