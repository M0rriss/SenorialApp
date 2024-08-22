using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Mesa
{
    public class VwMesaDetalle
    {
        public int IdPedidoMesa { get; set; }
        public int IdMesaDetalle { get; set; }
        public string? NombreProducto { get; set; }
        public int CantidadItems { get; set; }
        public decimal SubTotal { get; set; }
    }
}
