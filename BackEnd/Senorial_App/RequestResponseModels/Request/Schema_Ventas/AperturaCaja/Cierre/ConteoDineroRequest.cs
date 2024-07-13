using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.AperturaCaja.Cierre
{
    public class ConteoDineroRequest
    {
        public decimal Denominacion { get; set; }
        public int Cantidad { get; set; }
    }
}
