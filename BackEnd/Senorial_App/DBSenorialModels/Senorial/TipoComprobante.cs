using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("tipo_comprobantes", Schema = "Ventas")]
public partial class TipoComprobante
{
    [Key]
    [Column("id_comprobante")]
    public int IdComprobante { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [InverseProperty("IdComprobanteNavigation")]
    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    [InverseProperty("IdComprobanteNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
