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
    public class UserDTO
    {
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; } = "";
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
