using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[PrimaryKey("IdProduccion", "IdProductoSucursal")]
[Table("detalle_produccion", Schema = "Produccion")]
public partial class DetalleProduccion
{
    [Key]
    [Column("id_produccion")]
    public int IdProduccion { get; set; }

    [Key]
    [Column("id_producto_sucursal")]
    public int IdProductoSucursal { get; set; }

    [Column("cantidad_salida")]
    public int? CantidadSalida { get; set; }

    [Column("fecha_salida", TypeName = "datetime")]
    public DateTime? FechaSalida { get; set; }

    [ForeignKey("IdProduccion")]
    [InverseProperty("DetalleProduccions")]
    public virtual Produccion IdProduccionNavigation { get; set; } = null!;

    [ForeignKey("IdProductoSucursal")]
    [InverseProperty("DetalleProduccions")]
    public virtual ProductoSucursal IdProductoSucursalNavigation { get; set; } = null!;
}
