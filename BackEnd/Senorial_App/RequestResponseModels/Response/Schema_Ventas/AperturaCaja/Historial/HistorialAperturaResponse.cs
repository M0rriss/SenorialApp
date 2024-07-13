using RequestResponseModels.Response.Schema_Ventas.Ventas.Detalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Historial
{
    public class HistorialAperturaResponse
    {
        public int IdApertura { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal TotalIngresos { get; set; }
        public List<VentaDetalleResponse> Ventas { get; set; }
    }
}
