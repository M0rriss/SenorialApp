using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("detalle_mesa", Schema = "Ventas")]
public partial class DetalleMesa
{
    [Key]
    [Column("id_mesa_detalle")]
    public int IdMesaDetalle { get; set; }

    [Column("id_mesa")]
    public int IdMesa { get; set; }

    [Column("id_ambiente")]
    public int IdAmbiente { get; set; }

    [ForeignKey("IdAmbiente")]
    [InverseProperty("DetalleMesas")]
    public virtual Ambiente IdAmbienteNavigation { get; set; } = null!;

    [ForeignKey("IdMesa")]
    [InverseProperty("DetalleMesas")]
    public virtual Mesa IdMesaNavigation { get; set; } = null!;

    [InverseProperty("IdMesaDetalleNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
