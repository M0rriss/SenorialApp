using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Usuarios.Roles
{
    public class RolesResponse
    {
        public int IdRol { get; set; }
        public string? Nombre { get; set; }
        public string? Abreviacion { get; set; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
