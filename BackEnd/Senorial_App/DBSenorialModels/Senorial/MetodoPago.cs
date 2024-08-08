using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("metodo_pago", Schema = "Ventas")]
public partial class MetodoPago
{
    [Key]
    [Column("id_metodo")]
    public int IdMetodo { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }
    [Column("estado")]
    [StringLength(100)]
    public bool Estado{ get; set; }

    [InverseProperty("IdMetodoNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
    [NotMapped]
    // Propiedad calculada para obtener el estado como cadena
    public string EstadoDescripcion
    {
        get
        {
            return Estado ? "Activo" : "Inactivo";
        }
    }
}
