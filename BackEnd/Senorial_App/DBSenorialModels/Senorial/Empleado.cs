using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("empleado", Schema = "Ventas")]
public partial class Empleado
{
    [Key]
    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("id_rol")]
    public int IdRol { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("id_sucursal")]
    public int IdSucursal { get; set; }
    [Column("estado")]
    [StringLength(100)]
    public bool? Estado { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("Empleados")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("Empleados")]
    public virtual Role IdRolNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("Empleados")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [InverseProperty("IdEmpleadoNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
    [InverseProperty("Empleado")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    [InverseProperty("Empleado")]
    public virtual ICollection<PedidoLlevar> PedidosLlevar { get; set; } = new List<PedidoLlevar>();
}
