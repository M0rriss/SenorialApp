using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Usuarios;
using Microsoft.EntityFrameworkCore;
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

        public Usuario ObtenerPorUserName(string userName)
        {
            Usuario usuario = dbset.Where(x => x.UserName.ToLower() == userName.ToLower()).Include(x=> x.IdRolNavigation.Nombre).FirstOrDefault();
            return usuario;
        }
    }
}
