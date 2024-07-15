using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestResponseModels.Request.Schema_Ventas.DetalleVentas;

namespace RequestResponseModels.Request.Schema_Ventas.Ventas
{
    public class VentasRequest
    {
        public int IdApertura { get; set; }
        public string ClienteNombre { get; set; }
        public string EmpleadoNombre { get; set; }
        public int IdComprobante { get; set; }
        public int IdVoucher { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        public int IdMetodo { get; set; }
        public string? NroDocumento { get; set; }
        public string? NroSerie { get; set; }
        public int IdTipoPedido { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Igv { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal? Vuelto { get; set; }
        public string? Observacion { get; set; }
        public List<DetalleVentaRequest> Detalles { get; set; } = new List<DetalleVentaRequest>();
    }
}
