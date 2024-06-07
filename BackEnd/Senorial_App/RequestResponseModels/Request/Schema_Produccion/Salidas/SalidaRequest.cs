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
        public int IdDetInventario { get; set; }
        public int IdProduccion { get; set; }
        public int? Cantidad { get; set; }
        public int IdSucursal { get; set; }
    }
}
