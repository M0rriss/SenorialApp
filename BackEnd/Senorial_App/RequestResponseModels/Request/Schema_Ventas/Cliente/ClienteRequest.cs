using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Cliente
{
    public class ClienteRequest
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
    }
}
