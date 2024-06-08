using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.SucursalUsuario;
using RequestResponseModels.Response.Schema_Ventas.SucursalUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.SucursalUsuario
{
    public interface SucursalUsuarioBusiness : ICrudBusiness<SucursalUsuarioRequest, SucursalUsuarioResponse>
    {
    }
}
