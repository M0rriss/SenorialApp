using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.Roles
{
    public interface IRolesBusiness : ICrudBusiness<RolesRequest, RolesResponse>
    {
        Task<RolesResponse> GetByRol(string rol);
    }
}
