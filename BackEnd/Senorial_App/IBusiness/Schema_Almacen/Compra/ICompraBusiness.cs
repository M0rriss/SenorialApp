using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Compra;
using RequestResponseModels.Response.Schema_Almacen.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Compra
{
    public interface ICompraBusiness : ICrudBusiness<CompraRequest, CompraResponse>
    {
    }
}
