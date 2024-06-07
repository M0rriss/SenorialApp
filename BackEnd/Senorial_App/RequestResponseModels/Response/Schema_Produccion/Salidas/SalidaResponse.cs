using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Produccion.Salidas
{
    public class SalidaResponse
    {
        public int IdDetInventario { get; set; }
        public int IdProduccion { get; set; }
        public int? Cantidad { get; set; }
        public int IdSucursal { get; set; }
    }
}
