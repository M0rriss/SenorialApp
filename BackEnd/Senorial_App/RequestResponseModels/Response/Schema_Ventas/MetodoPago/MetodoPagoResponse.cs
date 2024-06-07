using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.MetodoPago
{
    public class MetodoPagoResponse
    {
        public int IdMetodo { get; set; }
        public string? Descripcion { get; set; }
    }
}
