using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("proveedor", Schema = "Almacen")]
public partial class Proveedor
{
    [Key]
    [Column("id_proveedor")]
    public int IdProveedor { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("vende")]
    [StringLength(50)]
    public string? Vende { get; set; }

    //[InverseProperty("IdProveedorNavigation")]
    //public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    [ForeignKey("IdPersona")]
    [InverseProperty("Proveedors")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
