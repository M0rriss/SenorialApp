using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Usuarios.Persona
{
    public class PersonaResponse
    {
        public int IdPersona { get; set; }
        public string? NroDocumento { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public string Genero { get; set; } = "";
        public string? TipoPersona { get; set; }
    }
}
