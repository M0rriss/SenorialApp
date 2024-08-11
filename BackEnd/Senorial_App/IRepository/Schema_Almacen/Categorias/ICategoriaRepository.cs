using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RequestResponseModels.Response.Schema_Almacen.Categorias.CategoriaResponse;

namespace IRepository.Schema_Almacen.Categorias
{
    public interface ICategoriaRepository : ICrudRepository<Categoria>
    {
        Task<List<CategoriaUiRequest>> UiCategoria();
        Task<Categoria> BuscarPorNombre(string nombre);
        Task<List<Categoria>> ListarCategoriaPadreAsync();
        Task<List<Categoria>> ListarSubCategoriaAsync(int idCategoria);
    }
}
