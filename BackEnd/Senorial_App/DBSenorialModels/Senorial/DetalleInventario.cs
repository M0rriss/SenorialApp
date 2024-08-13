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

    [ForeignKey("IdInsumo")]
    [InverseProperty("DetalleInventarios")]
    public virtual Insumo Insumo { get; set; } = null!;

    [ForeignKey("IdInventario")]
    //[InverseProperty("DetalleInventarios")]
    public virtual Inventario Inventario { get; set; } = null!;

    [NotMapped]
    public string EstadoStock => StockTotal > 16 ? "Suficiente" : StockTotal > 10 ? "En progreso" : "Agotándose";
}
