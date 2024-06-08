using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.Ubigeos;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Generico.Ubigeos
{
    public class UbigeoRepository : CrudRepository<Ubigeo>, IUbigeoRepository
    {
        public Task<GenericFilterResponse<Ubigeo>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
