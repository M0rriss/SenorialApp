using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("documentos", Schema = "Ventas")]
public partial class Documento
{
    [Key]
    [Column("id_documento")]
    public int IdDocumento { get; set; }

    [Column("nro_documento")]
    [StringLength(100)]
    public string? NroDocumento { get; set; }

    [Column("id_comprobante")]
    public int IdComprobante { get; set; }

    [ForeignKey("IdComprobante")]
    [InverseProperty("Documentos")]
    public virtual TipoComprobante IdComprobanteNavigation { get; set; } = null!;

    [InverseProperty("IdDocumentoNavigation")]
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
