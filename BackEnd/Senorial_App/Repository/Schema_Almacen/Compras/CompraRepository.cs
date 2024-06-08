using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Compras;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Compras
{
    public class CompraRepository : CrudRepository<Compra>, ICompraRepository
    {
        public Task<GenericFilterResponse<Compra>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
