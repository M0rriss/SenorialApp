using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.DetalleInventarios
{
    public class DetalleInventarioRequest
    {
        public int IdInventario { get; set; }
        public int IdInsumo { get; set; }
        public int StockTotal { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
