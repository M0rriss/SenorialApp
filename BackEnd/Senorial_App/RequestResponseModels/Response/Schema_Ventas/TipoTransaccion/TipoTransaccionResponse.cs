using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.TipoTransaccion
{
    internal class TipoTransaccionResponse
    {
        public int IdTipoTransaccion { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
