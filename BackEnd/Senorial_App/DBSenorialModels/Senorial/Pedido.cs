using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Senorial
{
    [Table("pedidos", Schema = "Ventas")]
    public partial class Pedido
    {
        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Column("id_empleado")]
        public int IdEmpleado { get; set; }

        [Column("id_mesa")]
        public int IdMesa { get; set; }

        [Column("fecha_pedido", TypeName = "datetime")]
        public DateTime FechaPedido { get; set; }

        [Column("estado")]
        public int? Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", 1,2,3

        [Column("total", TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }

        [Column("id_tipo_pedido")]
        public int IdTipoPedido { get; set; } // "Indoor" or "PickUp"

        [ForeignKey("IdTipoPedido")]
        [InverseProperty("Pedidos")] 
        public virtual TipoPedido TipoPedido { get; set; }

        [InverseProperty("Pedido")]
        public virtual ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

        [ForeignKey("IdMesa")]
        public virtual Mesa Mesa { get; set; } // Para obtener el nombre de la mesa

        [ForeignKey("IdEmpleado")]
        [InverseProperty("Pedidos")]  
        public virtual Empleado Empleado { get; set; }
    }
}