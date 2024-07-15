using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Mesas
{
    public class MesaResponse
    {
        public int IdMesa { get; set; }
        public string? Nombre { get; set; }
        public string Estado { get; set;}
    }
}
