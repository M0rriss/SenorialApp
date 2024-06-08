using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Ambiente;
using RequestResponseModels.Response.Schema_Ventas.Ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Ambiente
{
    public interface IAmbienteBusiness : ICrudBusiness<AmbienteRequest, AmbienteResponse>
    {
    }
}
