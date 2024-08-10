using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("categorias", Schema = "Almacen")]
[Index("Nombre", Name = "categorias_nombre_uk", IsUnique = true)]
public partial class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("estado")]
    [StringLength(100)]
    public bool Estado { get; set; }

    [Column("id_categoria_padre")]
    public int? IdCategoriaPadre { get; set; }

    [ForeignKey("IdCategoriaPadre")]
    [InverseProperty("SubCategorias")]
    public virtual Categoria? CategoriaPadre { get; set; }

    [InverseProperty("CategoriaPadre")]
    public virtual ICollection<Categoria> SubCategorias { get; set; } = new List<Categoria>();
    [InverseProperty("Categoria")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; } = new List<ProductoSucursal>();
    [NotMapped]
    // Propiedad calculada para obtener el estado como cadena
    public string EstadoDescripcion => Estado ? "Activo" : "Inactivo";
}
