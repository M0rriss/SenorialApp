using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Almacen.Compra
{
    public class CompraRequest
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdVoucher { get; set; }
    }
}
