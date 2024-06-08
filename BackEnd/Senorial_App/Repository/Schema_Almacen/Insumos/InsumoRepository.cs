using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Insumos;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Insumos
{
    public class InsumoRepository : CrudRepository<Insumo>, IInsumoRepository
    {
        public Task<GenericFilterResponse<Insumo>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
