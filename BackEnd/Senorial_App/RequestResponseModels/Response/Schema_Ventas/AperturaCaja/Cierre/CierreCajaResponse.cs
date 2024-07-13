using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Cierre
{
    public class CierreCajaResponse
    {
        public decimal TotalContado { get; set; }
        public decimal Sobrante { get; set; }
        public decimal Faltante { get; set; }
    }
}
