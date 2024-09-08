using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Mesa
{
    public class VwMesa
    {
        
        public int? IdPedido {  get; set; } 
        public int IdMesa { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int Estado { get; set; } 
    }

}
