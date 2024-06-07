using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Generico.UnidadMedicion
{
    public class UnidadMedicionRequest
    {
        public int IdUnidad { get; set; }
        [StringLength(50)]
        public string? Descripcion { get; set; }
        [StringLength(50)]
        public string? Abreviacion { get; set; }
    }
}
