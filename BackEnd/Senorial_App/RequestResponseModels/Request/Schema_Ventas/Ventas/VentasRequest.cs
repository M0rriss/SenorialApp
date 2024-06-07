using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Schema_Ventas.Ventas
{
    public class VentasRequest
    {
        public int IdVenta { get; set; }
        public int IdApertura { get; set; }
        public int IdVoucher { get; set; }
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
        public int IdEstado { get; set; }
        public int IdEmpleado { get; set; }
        public int IdMetodo { get; set; }
        public int IdComprobante { get; set; }
        [StringLength(50)]
        public string? NroDocumento { get; set; }
        [StringLength(50)]
        public string? NroSerie { get; set; }
        public int IdTipoPedido { get; set; }
        public DateTime? FechaVenta { get; set; }
        public decimal? CostoBase { get; set; }
        public decimal? Igv { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? Vuelto { get; set; }
        [StringLength(100)]
        public string? Observacion { get; set; }
    }
}
