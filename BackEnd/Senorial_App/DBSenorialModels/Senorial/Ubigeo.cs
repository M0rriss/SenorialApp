using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("ubigeo", Schema = "Generico")]
public partial class Ubigeo
{
    [Key]
    [Column("id_ubigeo")]
    public int IdUbigeo { get; set; }

    [Column("codigo")]
    [StringLength(12)]
    public string? Codigo { get; set; }

    [Column("distrito")]
    [StringLength(100)]
    public string? Distrito { get; set; }

    [Column("provincia")]
    [StringLength(100)]
    public string? Provincia { get; set; }

    [Column("departamento")]
    [StringLength(100)]
    public string? Departamento { get; set; }

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
