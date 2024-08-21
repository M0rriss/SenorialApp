using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.View.Mesa
{
    public class VwMesa
    {
        private int? _idPedido;
        public int? IdPedido
        {
            get { return _idPedido; }  // Retorna el valor almacenado
            set
            {
                // Establece null si se cumple una condición, por ejemplo, si el valor es negativo
                if (value < 0)
                {
                    _idPedido = null;
                }
                else
                {
                    _idPedido = value;
                }
            }
        }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public bool? Estado { get; set; } 
    }

}
