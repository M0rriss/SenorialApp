using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.DetalleInventario
{
    public class DetalleInventarioResponse
    {
        public int IdDetInventario { get; set; }
        public int IdInventario { get; set; }
        public int IdInsumo { get; set; }
        public int StockTotal { get; set; }
        public string Estado { get; set; }
    }
}
