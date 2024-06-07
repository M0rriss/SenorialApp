using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.AperturaCaja
{
    public class AperturaCajaRequest
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
