using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("ambiente", Schema = "Ventas")]
public partial class Ambiente
{
    [Key]
    [Column("id_ambiente")]
    public int IdAmbiente { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("id_mesa")]
    public int IdMesa { get; set; }

    [ForeignKey("IdMesa")]
    [InverseProperty("Ambientes")]
    public virtual Mesa IdMesaNavigation { get; set; } = null!;

    [InverseProperty("IdAmbienteNavigation")]
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
