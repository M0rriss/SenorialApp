using DBSenorialModels.Senorial;
using DBSenorialModels.View.Producto;
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
        private async Task<List<VwProductoEcommerce>> ListarProductosAsync()
        {
            List<VwProductoEcommerce> list = [];
            var query = await (from product in dbset
                        join imagen in db.Imagenes
                            on product.IdImg equals imagen.Id
                        join categoria in db.Categorias
                                    on product.IdCategoria equals categoria.IdCategoria
                        select new
                        {
                            product.IdProducto,
                            producto = product.Nombre,
                            product.Descripcion,
                            imagen.ImageData,
                            product.PrecioVenta,
                            categoria.IdCategoria,
                            categoria.IdCategoriaPadre,
                            
                        }).ToListAsync();
            foreach (var item in query) 
            {
                VwProductoEcommerce tmp = new()
                {
                    IdProducto = item.IdProducto,
                    NombreProducto = item.producto,
                    DetalleProducto = item.Descripcion,
                    PrecioVenta = item.PrecioVenta,
                    RutaImagen = item.ImageData,
                    CategoriaPadre = item.IdCategoriaPadre,
                    IdCategoria = item.IdCategoria,
                };
                list.Add(tmp);
            }
            return list;
        }
        private async Task<List<VwProductoDashboard>> ListarProductosDashboardAsync()
        {
            List<VwProductoDashboard> list = [];
            var query = await (from product in dbset
                               join imagen in db.Imagenes
                                    on product.IdImg equals imagen.Id
                               join categoria in db.Categorias
                                   on product.IdCategoria equals categoria.IdCategoria
                               select new
                               {
                                   product.IdProducto,
                                   producto = product.Nombre,
                                   product.Descripcion,
                                   product.PrecioVenta,
                                   product.Derivar,
                                   categoria.Nombre,
                                   categoria.IdCategoria,
                                   imagen.ImageData,
                               }).ToListAsync();
            foreach (var item in query)
            {
                VwProductoDashboard tmp = new()
                {
                    IdProducto = item.IdProducto,
                    NombreProducto = item.producto,
                    DetalleProducto = item.Descripcion,
                    PrecioVenta = item.PrecioVenta,
                    Derivar = item.Derivar,
                    Categoria = item.Nombre,
                    RutaImagen = item.ImageData,
                    IdCategoria = item.IdCategoria,
                };
                list.Add(tmp);
            }
            return list;
        }
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

        public async Task<GenericFilterResponse<VwProductoEcommerce>> GetByFilterViewProductEcommerceAsync(GenericFilterRequest request)
        {
            List<VwProductoEcommerce> list = await ListarProductosAsync();
            var query = list.Where(x => x.IdProducto == x.IdProducto);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "Categoria":
                            query = query.Where(x => x.CategoriaPadre == int.Parse(j.Value));
                            break;
                        case "SubCategoria":
                            query = query.Where(x => x.IdCategoria == int.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<VwProductoEcommerce> res = new();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad)
                .Take(request.Cantidad)
                .OrderBy(x => x.IdProducto)
                .ToList();

            return res;
        }
        public async Task<GenericFilterResponse<VwProductoDashboard>> GetByFilterViewProductDashboardAsync(GenericFilterRequest request)
        {
            List<VwProductoDashboard> list = await ListarProductosDashboardAsync();
            var query = list.Where(x => x.IdProducto == x.IdProducto);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "id":
                            query = query.Where(x => x.IdProducto == int.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<VwProductoDashboard> res = new();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad)
                .Take(request.Cantidad)
                .OrderBy(x => x.IdProducto)
                .ToList();

            return res;
        }
    }
}
