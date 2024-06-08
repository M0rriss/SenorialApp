using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Produccion.Salidas;
using RequestResponseModels.Response.Schema_Produccion.Salidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Produccion.Salidas
{
    public interface ISalidaBusiness : ICrudBusiness<SalidaRequest, SalidaResponse>
    {
    }
}
