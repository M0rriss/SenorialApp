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
        public int IdMesa { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", etc.
        public decimal Total { get; set; }
        public string TipoPedido { get; set; } // "Indoor" or "PickUp"
        public List<DetallePedidoRequest> Detalles { get; set; }
    }
}
