using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Categorias;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Categorias
{
    public class CategoriaRepository : CrudRepository<Categoria>, ICategoriaRepository
    {
        public Task<GenericFilterResponse<Categoria>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
