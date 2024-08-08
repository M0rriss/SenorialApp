using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.MetodoPago
{
    public class MetodoPagoResponse
    {
        public int IdMetodo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }

        // Propiedad calculada para obtener el estado como cadena
        public string EstadoDescripcion
        {
            get
            {
                return Estado ? "Activo" : "Inactivo";
            }
        }
    }
    public class MetodoPagoUiResponse
    {
        public int IdMetodo { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        public string EstadoDescripcion
        {
            get
            {
                return Estado ? "Activo" : "Inactivo";
            }
        }
    }
}
