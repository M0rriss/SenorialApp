using DBSenorialModels.Senorial;
using DBSenorialModels.View.Almacen;
using DBSenorialModels.View.Almacen.DetalleIngreso;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Almacen.DetalleInventarios
{
    public interface IDetalleInventarioRepository : ICrudRepository<DetalleInventario>
    {
        Task<GenericFilterResponse<VwDetalleIngreos>> ListardetalleInventarioAsync(int page, int pagesize, string insumo);
        Task<VwBuscarInsumoDetalle> BuscarInsumoAsync(int idInsumo);
        Task<GenericFilterResponse<VwDetalleInsumos>> ListarDetalleInventario(int page, int pagesize, string insumo);
        Task<bool> EliminarInsumoAsync(int idInsumo);
    }
}
