using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Usuarios.MenuDash
{
    public class MenuDashResponse
    {
        public int IdMenu { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }
        public string? DataTarget { get; set; }
        public string? Url { get; set; }
        public int? Parent { get; set; }
    }
}
