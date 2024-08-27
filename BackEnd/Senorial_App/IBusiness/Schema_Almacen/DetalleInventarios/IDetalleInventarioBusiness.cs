using CommonModels.Common;
using DBSenorialModels.View.Almacen;
using DBSenorialModels.View.Almacen.DetalleIngreso;
using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Almacen.DetalleCompra;
using RequestResponseModels.Response.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.DetalleInventarios
{
    public interface IDetalleInventarioBusiness : ICrudBusiness<DetalleInventarioRequest, DetalleInventarioResponse>
    {
        Task<GenericFilterResponse<VwDetalleIngreos>> ListarInventarioAsync(int page, int pagesize, string insumo);
        Task<VwBuscarInsumoDetalle> BuscarSuministroAsync(int idInsumo);
        Task<GenericFilterResponse<VwDetalleInsumos>> ListarDetalleInventario(int page, int pagesize, string insumo);
        Task<CustomResponse> EliminarInsumo(int idInsumo);
    }
}
