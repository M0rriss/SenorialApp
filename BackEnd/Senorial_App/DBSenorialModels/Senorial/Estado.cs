using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("estado", Schema = "Generico")]
[Index("Nombre", Name = "estado_descripcion_uk", IsUnique = true)]
public partial class Estado
{
    [Key]
    [Column("id_estado")]
    public int IdEstado { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("abreviacion")]
    [StringLength(50)]
    public string? Abreviacion { get; set; }

    [Column("id_estado_padre")]
    public int? IdEstadoPadre { get; set; }

    [InverseProperty("IdEstadoNavigation")]
    public virtual ICollection<DetalleInventario> DetalleInventarios { get; set; } = new List<DetalleInventario>();

    [ForeignKey("IdEstadoPadre")]
    [InverseProperty("InverseIdEstadoPadreNavigation")]
    public virtual Estado? IdEstadoPadreNavigation { get; set; }

    [InverseProperty("IdEstadoPadreNavigation")]
    public virtual ICollection<Estado> InverseIdEstadoPadreNavigation { get; set; } = new List<Estado>();

    [InverseProperty("IdEstadoNavigation")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("IdEstadoNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    [InverseProperty("IdEstadoNavigation")]
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
