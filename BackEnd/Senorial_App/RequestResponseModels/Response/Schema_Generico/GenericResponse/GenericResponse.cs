using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Generico.GenericResponse
{
    public class GenericResponse
    {
        public bool Success { get; set; } = false;
        public string Codigo { get; set; } = "ERROR";
        public string Descripcion { get; set; } = "OCURRIO UN ERROR INTERNO";
        public string Mensaje { get; set; } = "Revise el código de error: ";
        public string MensajeSistema { get; set; } = "OCURRIO UN PERCANSE COMUNIQUESE CON EL ÁREA DE SISTEMAS";

    }
}
