using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Ambiente
{
    public class AmbienteRequest
    {
        public int IdAmbiente { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        public int IdMesa { get; set; }
    }
}
