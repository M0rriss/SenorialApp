using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("mesas", Schema = "Ventas")]
public partial class Mesa
{
    [Key]
    [Column("id_mesa")]
    public int IdMesa { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [InverseProperty("IdMesaNavigation")]
    public virtual ICollection<Ambiente> Ambientes { get; set; } = new List<Ambiente>();
}
