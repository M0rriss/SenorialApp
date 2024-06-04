using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.DetalleInventario
{
    public class DetalleInventarioRequest
    {
        public int IdDetInventario { get; set; }
        public int IdInventario { get; set; }
        public int IdInsumo { get; set; }
        public int StockTotal { get; set; }
        public int IdEstado { get; set; }
    }
}
