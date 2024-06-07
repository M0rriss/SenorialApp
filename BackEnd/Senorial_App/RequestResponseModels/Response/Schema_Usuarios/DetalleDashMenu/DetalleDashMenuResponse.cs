using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Usuarios.DetalleDashMenu
{
    public class DetalleDashMenuResponse
    {
        public int IdMenu { get; set; }
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }
}
