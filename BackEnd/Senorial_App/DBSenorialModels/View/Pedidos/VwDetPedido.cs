using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Pedidos
{
    public class VwDetPedido
    {
        public int IdPedido { get; set; }
        public string? NombreProducto { get; set; } = string.Empty;
        public int IdProducto { get; set; }
        public int idDetallePedido { get; set; }
        public int cantidad { get; set; }
        public string? DescripcionProducto { get; set; } = string.Empty;
        public decimal? PrecioProducto { get; set; }
        public string? UrlImagen { get; set; } = string.Empty;
    }
}
