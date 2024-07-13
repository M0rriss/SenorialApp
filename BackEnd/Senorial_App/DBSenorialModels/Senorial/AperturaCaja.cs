using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("apertura_cajas", Schema = "Ventas")]
public partial class AperturaCaja
{
    [Key]
    [Column("id_apertura")]
    public int IdApertura { get; set; }

    [Column("id_caja")]
    public int IdCaja { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("monto_inicio", TypeName = "decimal(10, 2)")]
    public decimal MontoInicio { get; set; }

    [Column("hora_fecha_inicio", TypeName = "datetime")]
    public DateTime HoraFechaInicio { get; set; }

    [Column("activo")]
    public bool Activo { get; set; }



    //CIERRE DE CAJA

    [Column("monto_cierre", TypeName = "decimal(10, 2)")]
    public decimal? MontoCierre { get; set; }
    [Column("total_contado", TypeName = "decimal(10, 2)")]
    public decimal? TotalContado { get; set; }
    [Column("sobrante", TypeName = "decimal(10, 2)")]
    public decimal? Sobrante { get; set; }
    [Column("faltante", TypeName = "decimal(10, 2)")]
    public decimal? Faltante { get; set; }

    [Column("hora_fecha_cierre", TypeName = "datetime")]
    public DateTime HoraFechaCierre { get; set; }

    [ForeignKey("IdCaja")]
    [InverseProperty("AperturaCajas")]
    public virtual Caja IdCajaNavigation { get; set; } = null!;

    [InverseProperty("IdAperturaNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    [InverseProperty("AperturaCaja")]
    public virtual ICollection<ConteoDinero> Conteos { get; set; } = new List<ConteoDinero>();
}
