using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("detalle_inventario", Schema = "Almacen")]
public partial class DetalleInventario
{
    [Key]
    [Column("id_det_inventario")]
    public int IdDetInventario { get; set; }

    [Column("id_inventario")]
    public int IdInventario { get; set; }

    [Column("id_insumo")]
    public int IdInsumo { get; set; }

    [Column("stock_total")]
    public int StockTotal { get; set; }

    [Column("estado")]
    public string Estado { get; set; }

    //[ForeignKey("IdEstado")]
    //[InverseProperty("DetalleInventarios")]
    //public virtual Estado IdEstadoNavigation { get; set; } = null!;

    [ForeignKey("IdInsumo")]
    [InverseProperty("DetalleInventarios")]
    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    [ForeignKey("IdInventario")]
    [InverseProperty("DetalleInventarios")]
    public virtual Inventario IdInventarioNavigation { get; set; } = null!;

    [InverseProperty("IdDetInventarioNavigation")]
    public virtual ICollection<Salida> Salida { get; set; } = new List<Salida>();
}
