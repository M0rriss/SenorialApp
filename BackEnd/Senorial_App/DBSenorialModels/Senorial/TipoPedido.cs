using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBSenorialModels.Senorial;

[Table("tipo_pedido", Schema = "Ventas")]
public partial class TipoPedido
{
    [Key]
    [Column("id_tipo_pedido")]
    public int IdTipoPedido { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTipoPedidoNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    [InverseProperty("TipoPedido")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    [InverseProperty("TipoPedido")]
    public virtual ICollection<PedidoLlevar> PedidosLlevar { get; set; } = new List<PedidoLlevar>();

}
