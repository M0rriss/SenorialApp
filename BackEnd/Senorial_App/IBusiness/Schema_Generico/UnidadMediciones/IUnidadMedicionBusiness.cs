using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.UnidadMedicion;
using RequestResponseModels.Response.Schema_Generico.UnidadMedicion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.UnidadMediciones
{
    public interface IUnidadMedicionBusiness : ICrudBusiness<UnidadMedicionRequest, UnidadMedicionResponse>
    {
    }
}
