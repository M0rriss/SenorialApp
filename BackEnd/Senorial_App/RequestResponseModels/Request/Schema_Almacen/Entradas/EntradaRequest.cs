using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.Entradas
{
    public class EntradaRequest
    {
        public int IdInventario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
    }
}
