using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Usuarios;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Usuarios.Usuarios
{
    public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public Task<GenericFilterResponse<Usuario>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
