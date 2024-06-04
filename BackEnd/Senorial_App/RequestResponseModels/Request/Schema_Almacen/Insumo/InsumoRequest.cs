using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.Insumo
{
    public class InsumoRequest
    {
        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public string? Url { get; set; }
        public int IdUnidad { get; set; }
    }
}
