using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Response.Schema_Almacen.Entradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Entradas
{
    public interface IEntradaBusiness : ICrudBusiness<EntradaRequest, EntradaResponse>
    {
    }
}
