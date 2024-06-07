using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.TipoPedido
{
    public class TipoPedidoResponse
    {
        public int IdTipoPedido { get; set; }
        public string? Descripcion { get; set; }
    }
}
