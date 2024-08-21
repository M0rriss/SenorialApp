using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Mesa
{
    public class VwMesaDetalle
    {
        public int IdMesaDetalle { get; set; }
        public string? NombreMesa { get; set; }
        public string? NombreProducto { get; set; }
        public int CantidadItems { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
