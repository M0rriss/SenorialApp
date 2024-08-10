using DBSenorialModels.Senorial;
using DBSenorialModels.View.Producto;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Productos
{
    public interface IProductoRepository : ICrudRepository<Producto>
    {
        Task<List<ProductoUiResponse>> UiProducto();
        Task<Producto> BuscarPorNombre(string nombre);
        Task<GenericFilterResponse<VwProductoEcommerce>> GetByFilterViewProductEcommerceAsync(GenericFilterRequest request);
        Task<GenericFilterResponse<VwProductoDashboard>> GetByFilterViewProductDashboardAsync(GenericFilterRequest request);
    }
}
