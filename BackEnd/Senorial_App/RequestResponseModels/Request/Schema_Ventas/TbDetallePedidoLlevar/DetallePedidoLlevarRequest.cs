using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.TbDetallePedidoLlevar
{
    public class DetallePedidoLlevarRequest
    {
        private int _idPedidoLlevar = 0;
        private int _idProducto = 0;
        private int _cantidad = 0;
        private decimal _precioUnitario = 0;

        public int IdPedidoLlevar { get => _idPedidoLlevar; set => _idPedidoLlevar = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
    }
}
