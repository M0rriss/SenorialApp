using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.PersonaJuridicas;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Usuarios.PersonaJuridicas
{
    public class PersonaJuridicaRepository : CrudRepository<PersonaJuridica>, IPersonaJuridicaRepository
    {
        public Task<GenericFilterResponse<PersonaJuridica>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
