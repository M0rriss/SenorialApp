using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.ProductoSucursal
{
    public class ProductoSucursalResponse
    {
        public int IdProductoSucursal { get; set; }
        public int IdUnidad { get; set; }
        public int IdCategoria { get; set; }
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public decimal? Precio { get; set; }
        public int? Cantidad { get; set; }
    }
}
