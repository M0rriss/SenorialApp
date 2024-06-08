using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.AperturaCaja
{
    public interface IAperturaCajaBusiness : ICrudBusiness<AperturaCajaRequest, AperturaCajaResponse>
    {
    }
}
