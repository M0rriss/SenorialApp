using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.AperturaCaja
{
    public class AperturaCajaResponse
    {
        public int IdApertura { get; set; }
        public DateTime HoraFechaInicio { get; set; }
        public decimal MontoInicio { get; set; }
        public bool Activo { get; set; }
    }
}
