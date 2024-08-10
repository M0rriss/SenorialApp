using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Productos
{
    public class ProductoEcommerceResponse
    {
        private int _idProducto = 0;
        private string _nombreProducto = string.Empty;
        private string _detalleProducto = string.Empty;
        private string _rutaImagen = string.Empty;
        private decimal? _precioVenta = 0;

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public string DetalleProducto { get => _detalleProducto; set => _detalleProducto = value; }
        public string RutaImagen { get => _rutaImagen; set => _rutaImagen = value; }
        public decimal? PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
    }
}
