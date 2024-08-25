using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Senorial
{
    [Table("pedidoLlevar", Schema = "Ventas")]
    public partial class PedidoLlevar
    {
        [Key]
        [Column("id_pedido_llevar")]
        public int IdPedidoLlevar { get; set; }
        [Column("id_empleado")]
        public int IdEmpleado { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("fecha_pedido", TypeName = "datetime")]
        public DateTime FechaPedido { get; set; }

        [Column("estado")]
        public int? Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", 1,2,3

        [Column("total", TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }

        [Column("id_tipo_pedido")]
        public int IdTipoPedido { get; set; } // "Indoor" or "PickUp"

        [ForeignKey("IdTipoPedido")]
        [InverseProperty("PedidosLlevar")]
        public virtual TipoPedido TipoPedido { get; set; }

        [InverseProperty("PedidoLlevar")]
        public virtual ICollection<DetallePedidoLlevar> DetallesLlevar { get; set; } = new List<DetallePedidoLlevar>();


        [ForeignKey("IdEmpleado")]
        [InverseProperty("PedidosLlevar")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("IdCliente")]
        [InverseProperty("PedidosLlevar")]
        public virtual Cliente Cliente { get; set; }
    }
}
