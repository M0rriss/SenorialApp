using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Proveedores;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Proveedores
{
    public class ProveedorRepository : CrudRepository<Proveedor>, IProveedorRepository
    {
        public Task<GenericFilterResponse<Proveedor>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
