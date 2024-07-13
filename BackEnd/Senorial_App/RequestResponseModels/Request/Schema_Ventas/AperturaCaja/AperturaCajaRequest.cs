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
        public int IdCaja { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoInicio { get; set; }
    }
}
