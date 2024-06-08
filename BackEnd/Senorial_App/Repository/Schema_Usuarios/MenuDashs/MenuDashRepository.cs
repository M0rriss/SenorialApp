using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.MenuDashs;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Usuarios.MenuDashs
{
    public class MenuDashRepository : CrudRepository<MenuDash>, IMenuDashRepository
    {
        public Task<GenericFilterResponse<MenuDash>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
