using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.DetallePedidos
{
    public class DetallePedidoLlevarResponse
    {
        public int IdDetallePedidoLlevar { get; set; }
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
