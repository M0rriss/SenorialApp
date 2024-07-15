using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Senorial
{
    [Table("detalle_pedido", Schema = "Ventas")]
    public partial class DetallePedido
    {
        [Key]
        [Column("id_detalle_pedido")]
        public int IdDetallePedido { get; set; }

        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario", TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; } // Para obtener el nombre del producto
    }
}
