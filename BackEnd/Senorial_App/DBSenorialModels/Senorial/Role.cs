using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("roles", Schema = "Usuarios")]
public partial class Role
{
    [Key]
    [Column("id_rol")]
    public int IdRol { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("abreviacion")]
    [StringLength(10)]
    public string? Abreviacion { get; set; }

    [Column("estado")]
    public string Estado { get; set; }

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
