using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("cliente", Schema = "Ventas")]
public partial class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("Clientes")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
