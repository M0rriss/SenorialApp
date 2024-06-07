using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Voucher
{
    public class VoucherRequest
    {
        public int IdVoucher { get; set; }
        [StringLength(50)]
        public string? FechaEmision { get; set; }
        [StringLength(50)]
        public string? Cantidad { get; set; }
        [StringLength(50)]
        public string? PrecioUnitario { get; set; }
        [StringLength(50)]
        public string? Igv { get; set; }
        [StringLength(50)]
        public string? ImporteTotal { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoTransaccion { get; set; }
    }
}
