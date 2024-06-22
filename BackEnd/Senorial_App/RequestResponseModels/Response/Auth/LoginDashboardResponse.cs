using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Auth
{
    public class LoginDashboardResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "user or password incorrect";
        public string Token { get; set; } = "";
        public string TokenExpira { get; set; } = "";

        public UsuarioResponse Usuario { get; set; } = new UsuarioResponse();
        public RolesResponse RolName { get; set; } = new RolesResponse();

    }
}
