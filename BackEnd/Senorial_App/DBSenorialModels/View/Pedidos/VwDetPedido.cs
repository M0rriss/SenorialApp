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
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal? PrecioProducto { get; set; }
        public string UrlImagen { get; set; }
    }
}
