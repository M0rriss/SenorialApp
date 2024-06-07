using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.DetalleVentas
{
    public class DetalleVentaResponse
    {
        public int IdDetVenta { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int IdVenta { get; set; }
        public int IdProductoSucursal { get; set; }
    }
}
