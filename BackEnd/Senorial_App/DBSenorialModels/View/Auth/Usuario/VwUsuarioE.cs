using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Auth.Usuario
{
    public class VwUsuarioE
    {
        public int IdPerson { get; set; } = 0;
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public int IdRol { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int IdUsuario { get; set; } = 0;
    }
}
