using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
