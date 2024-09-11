using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.PedidosLlevar
{
    public class VwPedidoLlevar
    {
        public int IdPedidoLlevar { get; set; }
        public string NombresCompletosCliente { get; set; }
        public string NombreEmpleado { get; set; }

        public string TipoPedido {  get; set; }
        public int CantidadTotal { get; set; }
        public int? Estado { get; set; }


    }
    
}
