using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("produccion", Schema = "Produccion")]
public partial class Produccion
{
    [Key]
    [Column("id_produccion")]
    public int IdProduccion { get; set; }

    [Column("cantidad_total")]
    public int CantidadTotal { get; set; }

    [Column("motivo")]
    [StringLength(200)]
    public string Motivo { get; set; } = null!;

    [InverseProperty("IdProduccionNavigation")]
    public virtual ICollection<DetalleProduccion> DetalleProduccions { get; set; } = new List<DetalleProduccion>();

    [InverseProperty("IdProduccionNavigation")]
    public virtual ICollection<Salida> Salida { get; set; } = new List<Salida>();
}
