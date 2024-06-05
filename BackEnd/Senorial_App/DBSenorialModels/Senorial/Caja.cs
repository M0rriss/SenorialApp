using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("cajas", Schema = "Ventas")]
public partial class Caja
{
    [Key]
    [Column("id_caja")]
    public int IdCaja { get; set; }

    [Column("numero_caja")]
    [StringLength(100)]
    public string NumeroCaja { get; set; } = null!;

    [InverseProperty("IdCajaNavigation")]
    public virtual ICollection<AperturaCaja> AperturaCajas { get; set; } = new List<AperturaCaja>();
}
