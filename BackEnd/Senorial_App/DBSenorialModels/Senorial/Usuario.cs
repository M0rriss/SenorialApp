using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("usuario", Schema = "Usuarios")]
[Index("UserName", Name = "usuario_user_name_uk", IsUnique = true)]
[Index("Email", Name = "usuario_user_email_uk", IsUnique = true)]
public partial class Usuario
{

    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("user_name")]
    [StringLength(50)]
    public string? UserName { get; set; }

    [Column("password")]
    [StringLength(50)]
    public string? Password { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [Column("id_rol")]
    public int IdRol { get; set; }

    //[Column("id_img")]
    //public int? IdImg { get; set; } 

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("cambiar_password")]
    [StringLength(100)]
    public string CambiarPassword { get; set; } = "";

    [ForeignKey("IdImg")]
    [InverseProperty("Usuarios")]
    public virtual Imagene? IdImgNavigation { get; set; } = null!;

    [ForeignKey("IdPersona")]
    [InverseProperty("Usuarios")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios")]
    public virtual Role IdRolNavigation { get; set; } = null!;

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<SucursalUsuario> SucursalUsuarios { get; set; } = new List<SucursalUsuario>();
}
