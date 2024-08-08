using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Produccion.Salidas
{
    public class SalidaRequest
    {
        public int IdInventario { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
    }
}
