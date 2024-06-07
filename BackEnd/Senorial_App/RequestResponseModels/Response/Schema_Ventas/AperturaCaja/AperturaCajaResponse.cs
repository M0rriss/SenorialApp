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
        public int IdCaja { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoInicio { get; set; }
        public DateTime HoraFechaInicio { get; set; }
        public bool Activo { get; set; }
        public decimal? MontoCierre { get; set; }
        public DateTime HoraFechaCierre { get; set; }
    }
}
