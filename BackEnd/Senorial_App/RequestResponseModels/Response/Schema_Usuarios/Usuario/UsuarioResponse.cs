using RequestResponseModels.Response.Schema_Usuarios.Persona;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Response.Schema_Usuarios.Usuario
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int IdPersona { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int IdRol { get; set; }
        //public int IdImg { get; set; } = 0;
        public string Email { get; set; }
        public string? CambiarPassword { get; set; }
        public string CodigoRecuperacion { get; set; } = "";
    }
    public class UsuarioUiResponse
    {
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string? Contrasena { get; set; }
        public PersonaResponse Persona { get; set; }
    }
}
