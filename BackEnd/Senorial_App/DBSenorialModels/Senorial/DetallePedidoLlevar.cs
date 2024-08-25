using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Senorial
{
    [Table("detalle_pedido_llevar", Schema = "Ventas")]
    public partial class DetallePedidoLlevar
    {
        [Key]
        [Column("id_detalle_pedido_llevar")]
        public int IdDetallePedidoLlevar { get; set; }

        [Column("id_pedido_llevar")]
        public int IdPedidoLlevar { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario", TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("IdPedidoLlevar")]
        public virtual PedidoLlevar PedidoLlevar { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; } // Para obtener el nombre del producto
    }
}
