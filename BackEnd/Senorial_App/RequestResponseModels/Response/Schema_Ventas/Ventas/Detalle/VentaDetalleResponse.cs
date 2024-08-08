using RequestResponseModels.Response.Schema_Ventas.DetalleVentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.Ventas.Detalle
{
    public class VentaDetalleResponse
    {
        public int IdVenta { get; set; }
        public string Cliente { get; set; }  // Nombre del cliente
        public decimal Monto { get; set; }
        public string TipoTransaccion { get; set; }  // Efectivo, Tarjeta, etc.
        public DateTime FechaHoraVenta { get; set; }
        public string Empleado { get; set; }  // Nombre del empleado que realizó la venta
        public List<DetalleVentaResponse> Detalles { get; set; } // Lista de detalles
    }
}
