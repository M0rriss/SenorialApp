using RequestResponseModels.Response.Schema_Ventas.DetallePedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Pedidos
{
    public class PedidoResponse
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; }
        public string MesaNombre { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", etc.
        public decimal Total { get; set; }
        public string TipoPedido { get; set; } // "Indoor" or "PickUp"
        public List<DetallePedidoResponse> Detalles { get; set; }
    }
}
