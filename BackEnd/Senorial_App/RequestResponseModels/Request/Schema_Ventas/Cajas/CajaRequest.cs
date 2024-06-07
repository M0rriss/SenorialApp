using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Cajas
{
    public class CajaRequest
    {
        public int IdCaja { get; set; }
        [StringLength(100)]
        public string NumeroCaja { get; set; }
    }
}
