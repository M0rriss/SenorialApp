using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("sucursal", Schema = "Generico")]
public partial class Sucursal
{
    [Key]
    [Column("id_sucursal")]
    public int IdSucursal { get; set; }

    [Column("id_ambiente")]
    public int? IdAmbiente { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("direccion")]
    [StringLength(200)]
    public string? Direccion { get; set; }
       
    [Column("id_documento")]
    public int? IdDocumento { get; set; }

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [ForeignKey("IdAmbiente")]
    [InverseProperty("Sucursals")]
    public virtual Ambiente? IdAmbienteNavigation { get; set; } = null!;

    [ForeignKey("IdDocumento")]
    [InverseProperty("Sucursals")]
    public virtual Documento? IdDocumentoNavigation { get; set; } = null!;

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; } = new List<ProductoSucursal>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Salida> Salida { get; set; } = new List<Salida>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<SucursalUsuario> SucursalUsuarios { get; set; } = new List<SucursalUsuario>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
