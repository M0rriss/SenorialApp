using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Entradas
{
    public class EntradaResponse
    {
        public int IdInventario { get; set; }
        public int IdCompra { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Cantidad { get; set; }
    }
}
