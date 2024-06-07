using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.DetalleVentas
{
    public class DetalleVentaRequest
    {
        public int IdDetVenta { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int IdVenta { get; set; }
        public int IdProductoSucursal { get; set; }
    }
}
