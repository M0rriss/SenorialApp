using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Roles;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Role> GetByRol(string rolName)
        {
            var roles = await dbset.ToListAsync();
            var rol = roles.FirstOrDefault(x => x.Nombre.Equals(rolName, StringComparison.OrdinalIgnoreCase));
            return rol;

        }
    }
}
