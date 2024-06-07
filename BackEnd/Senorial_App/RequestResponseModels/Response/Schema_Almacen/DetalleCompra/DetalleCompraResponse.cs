using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.DetalleCompra
{
    public class DetalleCompraResponse
    {
        public int IdCompra { get; set; }
        public int IdInsumo { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}
