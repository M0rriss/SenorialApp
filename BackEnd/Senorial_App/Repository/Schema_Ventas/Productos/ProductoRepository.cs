using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Productos;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Productos
{
    public class ProductoRepository : CrudRepository<Producto>, IProductoRepository
    {
        public Task<GenericFilterResponse<Producto>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
