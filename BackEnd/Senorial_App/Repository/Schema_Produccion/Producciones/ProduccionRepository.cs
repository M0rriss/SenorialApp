using DBSenorialModels.Senorial;
using IRepository.Schema_Produccion.Producciones;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Produccion.Producciones
{
    public class ProduccionRepository : CrudRepository<Produccion>, IProduccionRepository
    {
        public Task<GenericFilterResponse<Produccion>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
