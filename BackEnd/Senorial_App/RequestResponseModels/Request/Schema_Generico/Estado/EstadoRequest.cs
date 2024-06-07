using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Generico.Estado
{
    public class EstadoRequest
    {
        public int IdEstado { get; set; }
        [StringLength(50)]
        public string? Nombre { get; set; }
        [StringLength(50)]
        public string? Abreviacion { get; set; }
        public int? IdEstadoPadre { get; set; }
    }
}
