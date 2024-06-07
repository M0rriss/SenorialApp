using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Produccion.Produccion
{
    public class ProduccionResponse
    {
        public int IdProduccion { get; set; }
        public int CantidadTotal { get; set; }
        public string Motivo { get; set; }
    }
}
