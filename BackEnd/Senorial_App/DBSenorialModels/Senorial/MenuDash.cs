using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("menu_dash", Schema = "Usuarios")]
public partial class MenuDash
{
    [Key]
    [Column("id_menu")]
    public int IdMenu { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [Column("icono")]
    [StringLength(50)]
    public string? Icono { get; set; }

    [Column("data_target")]
    [StringLength(50)]
    public string? DataTarget { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("parent")]
    public int? Parent { get; set; }

    [InverseProperty("IdMenuNavigation")]
    public virtual ICollection<DetalleDashMenu> DetalleDashMenus { get; set; } = new List<DetalleDashMenu>();
}
