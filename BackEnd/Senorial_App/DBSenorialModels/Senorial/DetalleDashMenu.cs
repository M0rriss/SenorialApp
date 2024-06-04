using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[PrimaryKey("IdMenu", "IdRol")]
[Table("detalle_dash_menu", Schema = "Usuarios")]
public partial class DetalleDashMenu
{
    [Key]
    [Column("id_menu")]
    public int IdMenu { get; set; }

    [Key]
    [Column("id_rol")]
    public int IdRol { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdMenu")]
    [InverseProperty("DetalleDashMenus")]
    public virtual MenuDash IdMenuNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("DetalleDashMenus")]
    public virtual Role IdRolNavigation { get; set; } = null!;
}
