using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Producto
{
    public class VwProductoDashboard
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string DetalleProducto { get; set; } = string.Empty;
        public decimal? PrecioVenta { get; set; }
        public string Derivar { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string RutaImagen { get; set; } = string.Empty;
        public int IdCategoria { get; set; } = 0;
    }
}
