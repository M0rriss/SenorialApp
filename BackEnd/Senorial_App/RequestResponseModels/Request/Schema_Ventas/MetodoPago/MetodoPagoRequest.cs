using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.MetodoPago
{
    public class MetodoPagoRequest
    {
        public int IdMetodo { get; set; }
        [StringLength(100)]
        public string? Descripcion { get; set; }
    }
}
