using CommonModels.Common;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Almacen;
using DBSenorialModels.View.Almacen.DetalleIngreso;
using IBusiness.Schema_Almacen.DetalleInventarios;
using IRepository.Schema_Almacen.DetalleInventarios;
using Microsoft.AspNetCore.Http.Timeouts;
using Repository.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.DetalleCompra;
using RequestResponseModels.Response.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.DetalleInventarios
{
    public class DetalleInventarioBusiness : IDetalleInventarioBusiness
    {
        private readonly IDetalleInventarioRepository _detalleInventarioRepository = new DetalleInventarioRepository();

        public async Task<DetalleInventarioResponse> Create(DetalleInventarioRequest entity)
        {
            DetalleInventario detalle = new()
            {
                IdInventario = entity.IdInventario,
                IdInsumo = entity.IdInsumo,
                StockTotal = entity.StockTotal,
            };
            detalle = await _detalleInventarioRepository.Create(detalle);
            DetalleInventarioResponse res = new()
            {
                IdDetInventario = detalle.IdDetInventario,
                IdInsumo = detalle.IdInsumo,
                IdInventario = detalle.IdInventario,
                StockTotal = detalle.StockTotal,
            };

            return res;
        }

        public Task<List<DetalleInventarioResponse>> CreateMultiple(List<DetalleInventarioRequest> list)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleInventarioRequest>> DeleteMultiple(List<DetalleInventarioRequest> list)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleInventarioResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenericFilterResponse<DetalleInventarioResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleInventarioResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleInventarioResponse> Update(DetalleInventarioRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetalleInventarioResponse>> UpdateMultiple(List<DetalleInventarioRequest> list)
        {
            throw new NotImplementedException();
        }

        #region Funcionalidad
        public async Task<GenericFilterResponse<VwDetalleIngreos>> ListarInventarioAsync(int page, int pagesize, string insumo)
        {
            GenericFilterResponse<VwDetalleIngreos> list = await _detalleInventarioRepository.ListardetalleInventarioAsync(page,pagesize, insumo);
            return list;
        }
        public async Task<VwBuscarInsumoDetalle> BuscarSuministroAsync(int idInsumo)
        {
            VwBuscarInsumoDetalle res = await _detalleInventarioRepository.BuscarInsumoAsync(idInsumo);
            return res;
        }

        public async Task<GenericFilterResponse<VwDetalleInsumos>> ListarDetalleInventario(int page, int pagesize, string insumo)
        {
            GenericFilterResponse<VwDetalleInsumos> res = await _detalleInventarioRepository.ListarDetalleInventario(page, pagesize, insumo);
            return res;
        }

        public async Task<CustomResponse> EliminarInsumo (int idInsumo)
        {
            await _detalleInventarioRepository.EliminarInsumoAsync(idInsumo);
            CustomResponse res = new() {
                Code = "2000",
                Message = "Se elimino correctamente",
            };
            return res;
        }
        #endregion Funcionalidad
    }
}
