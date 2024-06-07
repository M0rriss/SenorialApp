using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Usuarios.MenuDash
{
    public class MenuDashRequest
    {
        public int IdMenu { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        [StringLength(100)]
        public string? Descripcion { get; set; }
        [StringLength(50)]
        public string? Icono { get; set; }
        [StringLength(50)]
        public string? DataTarget { get; set; }
        public string? Url { get; set; }
        public int? Parent { get; set; }
    }
}
