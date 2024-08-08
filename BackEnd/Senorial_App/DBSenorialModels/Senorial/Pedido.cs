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

        [Column("id_mesa")]
        public int IdMesa { get; set; }

        [Column("fecha_pedido", TypeName = "datetime")]
        public DateTime FechaPedido { get; set; }

        [Column("estado")]
        [StringLength(50)]
        public string Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", etc.

        [Column("total", TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }

        [Column("tipo_pedido")]
        [StringLength(50)]
        public string TipoPedido { get; set; } // "Indoor" or "PickUp"

        [InverseProperty("Pedido")]
        public virtual ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

        [ForeignKey("IdMesa")]
        public virtual Mesa Mesa { get; set; } // Para obtener el nombre de la mesa
    }
}