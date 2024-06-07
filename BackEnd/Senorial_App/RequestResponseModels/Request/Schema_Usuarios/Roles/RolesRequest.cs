using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.Roles
{
    public class RolesRequest
    {
        public int IdRol { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        [StringLength(10)]
        public string? Abreviacion { get; set; }
        [StringLength(100)]
        public string? Descripcion { get; set; }
        public int IdEstado { get; set; }
    }
}
