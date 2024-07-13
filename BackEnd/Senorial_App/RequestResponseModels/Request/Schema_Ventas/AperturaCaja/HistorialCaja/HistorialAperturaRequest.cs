using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja
{
    public class HistorialAperturaRequest
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdCaja { get; set; }
    }
}
