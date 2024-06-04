using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[PrimaryKey("IdSucursal", "IdUsuario")]
[Table("sucursal_usuario", Schema = "Ventas")]
public partial class SucursalUsuario
{
    [Key]
    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdSucursal")]
    [InverseProperty("SucursalUsuarios")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("SucursalUsuarios")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
