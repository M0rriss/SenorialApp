using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.Usuario
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        [StringLength(50)]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int IdPersona { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int IdRol { get; set; }
        public int IdImg { get; set; }
    }
}
