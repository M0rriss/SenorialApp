using CommonModels.Common;
using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Productos
{
    public interface IProductoBusiness : ICrudBusiness<ProductoRequest, ProductoResponse>
    {
        Task<List<ProductoUiResponse>> UiGetProducto();
        Task<ProductoUiResponse> InsertUiProducto(ProductoUiRequest request);
        Task<ProductoUiResponse> UpdateUiProducto(ProductoUpdateUiRequest request);
        Task<bool> DeleteUiProducto(int id);
        Task<GenericFilterResponse<ProductoEcommerceResponse>> FiltrarProductoAsync(GenericFilterRequest req);
        Task<GenericFilterResponse<ProductoDashboardResponse>> FiltrarProductoDashboardAsync(GenericFilterRequest req);
        Task<CustomResponse> CrearNuevoProductoAsync(ProductDashRequest req);
        Task<CustomResponse> EditarProductoAsync(ProductEditDashRequest req);
    }
}
