using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Categorias;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RequestResponseModels.Response.Schema_Almacen.Categorias.CategoriaResponse;

namespace Repository.Schema_Almacen.Categorias
{
    public class CategoriaRepository : CrudRepository<Categoria>, ICategoriaRepository
    {
        public Task<GenericFilterResponse<Categoria>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<List<CategoriaUiRequest>> UiCategoria()
        {
            var result = await (from c1 in dbset
                                join c2 in dbset on c1.IdCategoria equals c2.IdCategoriaPadre into subcategories
                                from sub in subcategories.DefaultIfEmpty()
                                where c1.IdCategoriaPadre == null && c1.Estado
                                group sub by new { c1.Nombre, c1.Estado } into grouped
                                select new CategoriaUiRequest
                                {
                                    Categoria = grouped.Key.Nombre,
                                    Subcategorias = string.Join(", ", grouped.Where(s => s != null && s.Estado).Select(s => s.Nombre)),
                                    Estado = grouped.Key.Estado ? "Activo" : "Inactivo",
                                })
                         .ToListAsync();

            return result;
        }

        public async Task<Categoria> BuscarPorNombre(string nombre)
        {
            var categoria = await dbset.ToListAsync();
            var categorias = categoria.FirstOrDefault(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return categorias;
        }

       public async Task<List<Categoria>> ListarCategoriaPadreAsync()
       {
            List<Categoria> list = [];
            var query = await (from categoria in dbset
                        where categoria.CategoriaPadre == null
                        select categoria).ToListAsync();

            foreach (var c in query) 
            {
                Categoria tmp = new()
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Estado= c.Estado,
                    IdCategoriaPadre = c.IdCategoriaPadre
                };
                list.Add(tmp);
            }

            return list;
       }

        public async Task<List<Categoria>> ListarSubCategoriaAsync(int idCategoria)
        {
            List<Categoria> list = [];
            var query = await (from categoria in dbset
                               where categoria.IdCategoriaPadre == idCategoria
                               select categoria).ToListAsync();

            foreach (var c in query)
            {
                Categoria tmp = new()
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Estado = c.Estado,
                    IdCategoriaPadre = c.IdCategoriaPadre
                };
                list.Add(tmp);
            }

            return list;
        }
    }
}