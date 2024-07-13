using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.AperturaCaja.Cierre
{
    public class CierreCajaRequest
    {
        public int IdApertura { get; set; }
        public List<ConteoDineroRequest> Conteos { get; set; }
    }
}
