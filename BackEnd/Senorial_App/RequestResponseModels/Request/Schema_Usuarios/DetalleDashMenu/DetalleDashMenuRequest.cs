using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.DetalleDashMenu
{
    public class DetalleDashMenuRequest
    {
        public int IdMenu { get; set; }
        public int IdRol { get; set; }
        [StringLength(100)]
        public string? Descripcion { get; set; }
    }
}
