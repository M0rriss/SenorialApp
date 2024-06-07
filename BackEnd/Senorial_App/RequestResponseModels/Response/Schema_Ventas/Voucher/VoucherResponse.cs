using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Voucher
{
    public class VoucherResponse
    {
        public int IdVoucher { get; set; }
        public string? FechaEmision { get; set; }
        public string? Cantidad { get; set; }
        public string? PrecioUnitario { get; set; }
        public string? Igv { get; set; }
        public string? ImporteTotal { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoTransaccion { get; set; }
    }
}
