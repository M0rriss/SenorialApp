using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.MenuDash;
using RequestResponseModels.Response.Schema_Usuarios.MenuDash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.MenuDash
{
    public interface IMenuDashBusiness : ICrudBusiness<MenuDashRequest,MenuDashResponse>
    {
    }
}
