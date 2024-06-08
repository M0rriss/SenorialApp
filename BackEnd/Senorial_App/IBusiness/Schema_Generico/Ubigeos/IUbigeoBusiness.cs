using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Ubigeo;
using RequestResponseModels.Response.Schema_Generico.Ubigeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.Ubigeos
{
    public interface IUbigeoBusiness : ICrudBusiness<UbigeoRequest, UbigeoResponse>
    {
    }
}
