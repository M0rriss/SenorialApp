using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Cajas;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Cajas
{
    public class CajaRepository : CrudRepository<Caja>, ICajaRepository
    {
        public Task<GenericFilterResponse<Caja>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
