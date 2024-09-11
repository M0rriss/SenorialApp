using RequestResponseModels.Request.Schema_Ventas.DetallePedidos;
using RequestResponseModels.Request.Schema_Ventas.TbDetallePedidoLlevar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.TbPedidoLlevar
{
    //public class PedidoLlevarRequest
    //{
    //    private int _idEmpleado = 0;
    //    private int _idCliente = 0;
    //    private int _idTipoPedido = 0;

    //    public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
    //    public int IdCliente { get => _idCliente; set => _idCliente = value; }
    //    public int IdTipoPedido { get => _idTipoPedido; set => _idTipoPedido = value; }
    //}
    public class OrdenLlevarRequest
    {
        public int IdPedidoLlevar { get; set; }
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public int Estado { get; set; } // "Carrito", "Preparandose", "Listo para servir", etc.
        public decimal Total { get; set; }
        public int IdTipoPedido { get; set; } // "Indoor" or "PickUp"
        public List<DetallePedidoLlevarRequest> DetallesLlevar { get; set; }
    }
}
