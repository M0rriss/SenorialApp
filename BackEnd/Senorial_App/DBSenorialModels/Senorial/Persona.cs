using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UtilityConstants.Enum.TipoDocumentoEnum;

namespace DBSenorialModels.Senorial;

[Table("personas", Schema = "Usuarios")]
[Index("Email", Name = "personas_email_uk", IsUnique = true)]
[Index("NroDocumento", Name = "personas_numero_documento_uk", IsUnique = true)]
[Index("Telefono", Name = "personas_phone_uk", IsUnique = true)]
[Index("RazonSocial", Name = "razon_social_phone_uk", IsUnique = true)]
public partial class Persona
{
    [Key]
    [Column("id_persona")]
    public int IdPersona { get; set; }
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
    [Column("nro_Documento")]
    [StringLength(100)]
    public string? NroDocumento { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("telefono")]
    [StringLength(12)]
    public string? Telefono { get; set; }

    [Column("direccion")]
    [StringLength(100)]
    public string? Direccion { get; set; }

    [Column("tipo_documento")]
    [StringLength(100)]
    public string TipoDocumento { get; set; }
    [Column("tipo_persona")]
    [StringLength(50)]
    public string? TipoPersona { get; set; }
    [Column("razon_social")]
    [StringLength(100)]
    public string? RazonSocial { get; set; }

    [Column("genero")]
    [StringLength(20)]
    public string Genero { get; set; } = null!;


    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    //[InverseProperty("IdPersonaNavigation")]
    //public virtual PersonaJuridica? PersonaJuridica { get; set; }

    //[InverseProperty("IdPersonaNavigation")]
    //public virtual PersonaNatural? PersonaNatural { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
