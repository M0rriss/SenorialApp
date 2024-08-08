using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Productos;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Productos;
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
        public async Task<List<ProductoUiResponse>> UiProducto()
        {
            return await db.Productos
                .Include(p => p.Categoria)
                .Select(p => new ProductoUiResponse
                {
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Derivar = p.Derivar,
                    Precio = (decimal)p.PrecioVenta,
                    Categoria = p.Categoria.Nombre
                })
                .ToListAsync();
        }
        public async Task<Producto> BuscarPorNombre(string nombre)
        {
            return await db.Productos
                .Where(p => p.Nombre.ToLower() == nombre.ToLower())
                .FirstOrDefaultAsync();
        }
    }
}
