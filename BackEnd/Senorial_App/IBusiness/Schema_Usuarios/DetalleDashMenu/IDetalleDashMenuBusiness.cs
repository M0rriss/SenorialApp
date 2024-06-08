using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.DetalleDashMenu;
using RequestResponseModels.Response.Schema_Usuarios.DetalleDashMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.DetalleDashMenu
{
    public interface IDetalleDashMenuBusiness : ICrudBusiness<DetalleDashMenuRequest, DetalleDashMenuResponse>
    {
    }
}
