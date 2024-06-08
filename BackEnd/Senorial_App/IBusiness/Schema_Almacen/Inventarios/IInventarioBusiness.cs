using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Inventario;
using RequestResponseModels.Response.Schema_Almacen.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Inventarios
{
    public interface IInventarioBusiness : ICrudBusiness<InventarioRequest, InventarioResponse>
    {
    }
}
