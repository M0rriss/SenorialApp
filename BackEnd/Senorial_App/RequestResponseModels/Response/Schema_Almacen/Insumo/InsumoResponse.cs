using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Insumo
{
    public class InsumoResponse
    {
        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public string? Url { get; set; }
        public int IdUnidad { get; set; }
    }
}
