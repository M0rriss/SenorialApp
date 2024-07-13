using DBSenorialModels.Senorial;
using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.Cierre;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Cierre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.AperturaCajas
{
    public interface IAperturaCajaBusiness : ICrudBusiness<AperturaCajaRequest, AperturaCajaResponse>
    {
        Task<CierreCajaResponse> CerrarCajaAsync(CierreCajaRequest request);
    }
}
