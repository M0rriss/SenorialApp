using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Roles;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Usuarios.Roles
{
    public class RolesRepository : CrudRepository<Role>, IRolesRepository
    {
        public Task<GenericFilterResponse<Role>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
