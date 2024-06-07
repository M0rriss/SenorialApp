using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Cajas
{
    public class CajaResponse
    {
        public int IdCaja { get; set; }
        public string NumeroCaja { get; set; }
    }
}
