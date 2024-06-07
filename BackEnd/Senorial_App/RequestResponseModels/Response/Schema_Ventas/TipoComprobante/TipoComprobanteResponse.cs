using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.TipoComprobante
{
    public class TipoComprobanteResponse
    {
        public int IdComprobante { get; set; }
        public string? Nombre { get; set; }
    }
}
