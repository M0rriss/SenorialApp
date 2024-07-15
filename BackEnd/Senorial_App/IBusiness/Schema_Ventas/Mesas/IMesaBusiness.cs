using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Mesas;
using RequestResponseModels.Response.Schema_Ventas.Mesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Mesas
{
    public interface IMesaBusiness : ICrudBusiness<MesaRequest, MesaResponse>
    {
        Task<MesaResponse> UpdateMesa(MesaUpdateRequest request);
    }
}
