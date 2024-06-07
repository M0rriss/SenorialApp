using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Generico.Estado
{
    public class EstadoResponse
    {
        public int IdEstado { get; set; }
        public string? Nombre { get; set; }
        public string? Abreviacion { get; set; }
        public int? IdEstadoPadre { get; set; }
    }
}
