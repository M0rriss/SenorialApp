using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Produccion.Salidas
{
    public class SalidaResponse
    {
        public int IdSalida { get; set; }
        public int IdInventario { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
    }
}
