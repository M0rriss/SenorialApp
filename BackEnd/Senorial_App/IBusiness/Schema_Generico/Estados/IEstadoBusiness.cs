using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Estado;
using RequestResponseModels.Response.Schema_Generico.Estado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.Estados
{
    public interface IEstadoBusiness : ICrudBusiness<EstadoRequest, EstadoResponse>
    {
    }
}
