using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.PedidosLlevar
{
    public class VwDetPedidoLlevar
    {
       
            public int IdPedidoLlevar { get; set; }
            public string? NombreProducto { get; set; } = string.Empty;
            public string? DescripcionProducto { get; set; } = string.Empty;
            public decimal? PrecioProducto { get; set; }
            public string? UrlImagen { get; set; } = string.Empty;
        
    }
}
