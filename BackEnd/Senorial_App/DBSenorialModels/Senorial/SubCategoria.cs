using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("sub_categorias", Schema = "Almacen")]
public partial class SubCategoria
{
    [Key]
    [Column("id_sub_categoria")]
    public int IdSubCategoria { get; set; }

    [Column("nombre_sub")]
    [StringLength(100)]
    public string? NombreSub { get; set; }

    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("SubCategoria")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    [InverseProperty("IdSubCategoriaNavigation")]
    public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; } = new List<ProductoSucursal>();
}
