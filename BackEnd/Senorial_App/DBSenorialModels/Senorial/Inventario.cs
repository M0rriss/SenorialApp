using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("inventario", Schema = "Almacen")]
public partial class Inventario
{

    [Key]
    [Column("id_inventario")]
    public int IdInventario { get; set; }

    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [Column("fecha_actualizacion", TypeName = "datetime")]
    public DateTime FechaActualizacion { get; set; } = DateTime.Now;

    [ForeignKey("IdSucursal")]
    public virtual Sucursal Sucursal { get; set; } = null!;

    [InverseProperty("Inventario")]
    public virtual ICollection<DetalleInventario> Detalles { get; set; } = new List<DetalleInventario>();

    [InverseProperty("Inventario")]
    public virtual ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();

    [InverseProperty("Inventario")]
    public virtual ICollection<Salida> Salidas { get; set; } = new List<Salida>();
}

