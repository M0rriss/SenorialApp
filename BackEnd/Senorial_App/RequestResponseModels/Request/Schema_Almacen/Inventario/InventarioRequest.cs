using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.Inventario
{
    public class InventarioRequest
    {
        public int IdSucursal { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
