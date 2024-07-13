using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja;
using RequestResponseModels.Request.Schema_Ventas.Cajas;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Historial;
using RequestResponseModels.Response.Schema_Ventas.Cajas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Cajas
{
    public interface ICajaBusiness : ICrudBusiness<CajaRequest, CajaResponse>
    {
        Task<AperturaCajaResponse> AperturarCaja(AperturaCajaRequest request);
        Task<List<HistorialAperturaResponse>> ObtenerHistorialApertura(HistorialAperturaRequest request);
    }
}
