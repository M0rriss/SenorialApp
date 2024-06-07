using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Categorias;
using Repository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Categorias
{
    public class CategoriaRepository : CrudRepository<Categoria>, ICategoriaRepository
    {
    }
}
