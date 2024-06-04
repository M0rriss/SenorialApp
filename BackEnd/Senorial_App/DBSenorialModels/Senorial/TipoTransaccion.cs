using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("tipo_transaccion", Schema = "Ventas")]
public partial class TipoTransaccion
{
    [Key]
    [Column("id_tipo_transaccion")]
    public int IdTipoTransaccion { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTipoTransaccionNavigation")]
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
