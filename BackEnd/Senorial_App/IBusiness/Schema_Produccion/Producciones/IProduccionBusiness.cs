using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Produccion.Produccion;
using RequestResponseModels.Response.Schema_Produccion.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Produccion.Producciones
{
    public interface IProduccionBusiness : ICrudBusiness<ProduccionRequest, ProduccionResponse>
    {
    }
}
