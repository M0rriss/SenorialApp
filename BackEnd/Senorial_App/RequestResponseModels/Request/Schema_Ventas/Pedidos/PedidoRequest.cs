using RequestResponseModels.Request.Schema_Ventas.DetallePedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Pedidos
{
    public class PedidoRequest
    {
        public int IdPedido { get; set; }
        public int IdEmpleado { get; set; }
        public int IdMesa { get; set; }
        public DateTime FechaPedido { get; set; }
        public int Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", etc.
        public decimal Total { get; set; }
        public int IdTipoPedido { get; set; } // "Indoor" or "PickUp"
        public List<DetallePedidoRequest> Detalles { get; set; }
    }
}
