using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Sucursal;
using RequestResponseModels.Response.Schema_Generico.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Generico.Sucursales
{
    public interface ISucursalBusiness : ICrudBusiness<SucursalRequest, SucursalResponse>
    {
    }
}
