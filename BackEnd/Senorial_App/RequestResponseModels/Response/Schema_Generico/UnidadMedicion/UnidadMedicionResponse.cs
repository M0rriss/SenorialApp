using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Generico.UnidadMedicion
{
    public class UnidadMedicionResponse
    {
        public int IdUnidad { get; set; }
        public string? Descripcion { get; set; }
        public string? Abreviacion { get; set; }
    }
}
