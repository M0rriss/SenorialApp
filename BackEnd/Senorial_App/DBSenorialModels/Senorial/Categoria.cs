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

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<SubCategoria> SubCategoria { get; set; } = new List<SubCategoria>();
}
