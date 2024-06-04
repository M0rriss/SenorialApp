using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Almacen.Compra
{
    public class CompraResponse
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdVoucher { get; set; }
    }
}
