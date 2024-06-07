using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Produccion.DetalleProduccion
{
    public class DetalleProduccionRequest
    {
        public int IdProduccion { get; set; }
        public int IdProductoSucursal { get; set; }
        public int? CantidadSalida { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
