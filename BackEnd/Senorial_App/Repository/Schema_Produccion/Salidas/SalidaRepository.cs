using DBSenorialModels.Senorial;
using IRepository.Schema_Produccion.Salidas;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Produccion.Salidas
{
    public class SalidaRepository : CrudRepository<Salida>, ISalidaRepository
    {
        public Task<GenericFilterResponse<Salida>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
