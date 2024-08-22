using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Pedidos
{
    public class VwPedido
    {
        public int IdPedido { get; set; }
        public string NombreMesa { get; set; }
        public string NombreEmpleado { get; set; }
        public string TipoPedido { get; set; }
        public int CantidadTotal { get; set; }
        public int? Estado { get; set; }
    }
}
