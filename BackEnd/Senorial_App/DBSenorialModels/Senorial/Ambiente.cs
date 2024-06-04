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

    [InverseProperty("IdAmbienteNavigation")]
    public virtual ICollection<DetalleMesa> DetalleMesas { get; set; } = new List<DetalleMesa>();
}
