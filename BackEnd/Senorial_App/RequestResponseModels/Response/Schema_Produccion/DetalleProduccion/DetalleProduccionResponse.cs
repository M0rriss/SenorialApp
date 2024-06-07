using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Produccion.DetalleProduccion
{
    public class DetalleProduccionResponse
    {
        public int IdProduccion { get; set; }
        public int IdProductoSucursal { get; set; }
        public int? CantidadSalida { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
