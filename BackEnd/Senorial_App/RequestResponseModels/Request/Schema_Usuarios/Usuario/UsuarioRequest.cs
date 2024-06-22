using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

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
        public int IdRol { get; set; }
        //public int IdImg { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(100)]
        public bool CambiarPassword { get; set; }
        public string CodigoRecuperacion { get; set; } = "";
    }
    public class UsuarioUiRequest
    {
        public string Nombres { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [PhoneValidation]
        public string Telefono { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
//    SELECT CONCAT(p.primer_nombre, ' ', p.segundo_nombre, ' ', p.apellido_paterno, ' ', p.apellido_materno) AS Nombres,
//      p.email AS Correo,
//       p.telefono AS Telefono,
//       r.nombre AS Rol,
//       e.nombre AS Estado
//FROM Usuarios.usuario u
//INNER JOIN Usuarios.personas p ON u.id_persona = p.id_persona
//INNER JOIN usuarios.roles r ON u.id_rol = r.id_rol
//INNER JOIN generico.estado e ON r.id_estado = e.id_estado;

}
