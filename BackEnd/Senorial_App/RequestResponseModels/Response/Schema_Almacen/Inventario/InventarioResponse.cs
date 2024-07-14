using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Inventario
{
    public class InventarioResponse
    {
        public int IdInventario { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
