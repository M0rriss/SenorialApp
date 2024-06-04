using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("imagenes", Schema = "Generico")]
public partial class Imagene
{
    [Key]
    [Column("id_img")]
    public int IdImg { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [InverseProperty("IdImgNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    [InverseProperty("IdImgNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
