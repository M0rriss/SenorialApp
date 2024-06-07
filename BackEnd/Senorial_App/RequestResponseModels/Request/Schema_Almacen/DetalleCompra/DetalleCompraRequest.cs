using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.DetalleCompra
{
    public class DetalleCompraRequest
    {
        public int IdCompra { get; set; }
        public int IdInsumo { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}
