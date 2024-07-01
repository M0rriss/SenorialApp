using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Auth
{
    public class LoginGenericResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "user or password incorrect";
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public UsuarioResponse Usuario { get; set; } = new UsuarioResponse();
        public RolesResponse Roles { get; set; } = new RolesResponse();
        public PersonaResponse Persona { get; set; } =new PersonaResponse();
    }
}
