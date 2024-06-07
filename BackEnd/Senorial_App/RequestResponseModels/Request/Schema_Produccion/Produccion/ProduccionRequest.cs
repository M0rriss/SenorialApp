using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Produccion.Produccion
{
    public class ProduccionRequest
    {
        public int IdProduccion { get; set; }
        public int CantidadTotal { get; set; }
        [StringLength(200)]
        public string Motivo { get; set; }
    }
}
