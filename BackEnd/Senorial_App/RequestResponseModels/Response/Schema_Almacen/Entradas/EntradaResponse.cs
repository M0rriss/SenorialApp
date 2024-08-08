using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Entradas
{
    public class EntradaResponse
    {
        public int IdEntrada { get; set; }
        public int IdInventario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
    }
}
