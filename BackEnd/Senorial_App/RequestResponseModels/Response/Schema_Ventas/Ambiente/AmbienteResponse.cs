using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Ambiente
{
    public class AmbienteResponse
    {
        public int IdAmbiente { get; set; }
        public string Nombre { get; set; }
        public int IdMesa { get; set; }
    }
}
