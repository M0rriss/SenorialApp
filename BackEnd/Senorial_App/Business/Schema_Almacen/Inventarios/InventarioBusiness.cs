using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.Inventarios;
using IRepository.Schema_Almacen.Inventarios;
using Repository.Schema_Almacen.Inventarios;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Almacen.Inventario;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Produccion.Salidas;
using RequestResponseModels.Response.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Almacen.Entradas;
using RequestResponseModels.Response.Schema_Almacen.Inventario;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Produccion.Salidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.Inventarios
{
    public class InventarioBusiness : IInventarioBusiness
    {
        #region Dependency Injecction
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IMapper _mapper;
        public InventarioBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _inventarioRepository = new InventarioRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<InventarioResponse>> GetAll()
        {
            List<Inventario> inventario = await _inventarioRepository.GetAll();
            var response = _mapper.Map<List<InventarioResponse>>(inventario);
            return response;
        }
        public async Task<InventarioResponse> GetById(int id)
        {
            var inventario = await _inventarioRepository.GetById(id);
            var response = _mapper.Map<InventarioResponse>(inventario);
            return response;
        }

        public async Task<InventarioResponse> Create(InventarioRequest entity)
        {
            var inventario = _mapper.Map<Inventario>(entity);
            inventario = await _inventarioRepository.Create(inventario);
            var response = _mapper.Map<InventarioResponse>(inventario);
            return response;
        }

        public async Task<List<InventarioResponse>> CreateMultiple(List<InventarioRequest> list)
        {
            var inventario = _mapper.Map<List<Inventario>>(list);
            inventario = await _inventarioRepository.CreateMultiple(inventario);
            var response = _mapper.Map<List<InventarioResponse>>(inventario);
            return response;
        }

        public async Task<InventarioResponse> Update(InventarioRequest entity)
        {
            var inventario = _mapper.Map<Inventario>(entity);
            inventario = await _inventarioRepository.Update(inventario);
            var response = _mapper.Map<InventarioResponse>(inventario);
            return response; ;
        }

        public async Task<List<InventarioResponse>> UpdateMultiple(List<InventarioRequest> list)
        {
            var inventario = _mapper.Map<List<Inventario>>(list);
            inventario = await _inventarioRepository.UpdateMultiple(inventario);
            var response = _mapper.Map<List<InventarioResponse>>(inventario);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _inventarioRepository.Delete(id);
            return result;
        }

        public async Task<List<InventarioRequest>> DeleteMultiple(List<InventarioRequest> list)
        {
            var inventario = _mapper.Map<List<Inventario>>(list);
            var deletedCount = await _inventarioRepository.DeleteMultiple(inventario);
            return list;

        }

        public async Task<GenericFilterResponse<InventarioResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _inventarioRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<InventarioResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _inventarioRepository.Dispose();
        }

        #endregion
        #region INVENTARIO UI
        public async Task<InventarioResponse> CreateInventario(InventarioRequest request)
        {
            return await Create(request);
        }

        public async Task<InventarioResponse> UpdateInventario(InventarioRequest request)
        {
            return await Update(request);
        }

        public async Task<bool> DeleteInventario(int id)
        {
            return await Delete(id) > 0;
        }

        public async Task<InventarioResponse> GetInventarioById(int id)
        {
            return await GetById(id);
        }

        public async Task<List<InventarioResponse>> GetAllInventarios()
        {
            return await GetAll();
        }

        public async Task<DetalleInventarioResponse> CreateDetalle(DetalleInventarioRequest request)
        {
            var detalle = _mapper.Map<DetalleInventario>(request);
            detalle = await _inventarioRepository.CreateDetalle(detalle);
            return _mapper.Map<DetalleInventarioResponse>(detalle);
        }

        public async Task<DetalleInventarioResponse> UpdateDetalle(DetalleInventarioRequest request)
        {
            var detalle = _mapper.Map<DetalleInventario>(request);
            detalle = await _inventarioRepository.UpdateDetalle(detalle);
            return _mapper.Map<DetalleInventarioResponse>(detalle);
        }

        public async Task<bool> DeleteDetalle(int id)
        {
            return await _inventarioRepository.DeleteDetalle(id);
        }

        public async Task<DetalleInventarioResponse> GetDetalleById(int id)
        {
            var detalle = await _inventarioRepository.GetDetalleById(id);
            return _mapper.Map<DetalleInventarioResponse>(detalle);
        }

        public async Task<List<DetalleInventarioResponse>> GetAllDetalles(int inventarioId)
        {
            var detalles = await _inventarioRepository.GetAllDetalles(inventarioId);
            return _mapper.Map<List<DetalleInventarioResponse>>(detalles);
        }

        public async Task<EntradaResponse> CreateEntrada(EntradaRequest request)
        {
            var entrada = _mapper.Map<Entrada>(request);
            entrada = await _inventarioRepository.CreateEntrada(entrada);
            return _mapper.Map<EntradaResponse>(entrada);
        }

        public async Task<EntradaResponse> UpdateEntrada(EntradaRequest request)
        {
            var entrada = _mapper.Map<Entrada>(request);
            entrada = await _inventarioRepository.UpdateEntrada(entrada);
            return _mapper.Map<EntradaResponse>(entrada);
        }

        public async Task<bool> DeleteEntrada(int id)
        {
            return await _inventarioRepository.DeleteEntrada(id);
        }

        public async Task<EntradaResponse> GetEntradaById(int id)
        {
            var entrada = await _inventarioRepository.GetEntradaById(id);
            return _mapper.Map<EntradaResponse>(entrada);
        }

        public async Task<List<EntradaResponse>> GetAllEntradas(int inventarioId)
        {
            var entradas = await _inventarioRepository.GetAllEntradas(inventarioId);
            return _mapper.Map<List<EntradaResponse>>(entradas);
        }

        public async Task<SalidaResponse> CreateSalida(SalidaRequest request)
        {
            var salida = _mapper.Map<Salida>(request);
            salida = await _inventarioRepository.CreateSalida(salida);
            return _mapper.Map<SalidaResponse>(salida);
        }

        public async Task<SalidaResponse> UpdateSalida(SalidaRequest request)
        {
            var salida = _mapper.Map<Salida>(request);
            salida = await _inventarioRepository.UpdateSalida(salida);
            return _mapper.Map<SalidaResponse>(salida);
        }

        public async Task<bool> DeleteSalida(int id)
        {
            return await _inventarioRepository.DeleteSalida(id);
        }

        public async Task<SalidaResponse> GetSalidaById(int id)
        {
            var salida = await _inventarioRepository.GetSalidaById(id);
            return _mapper.Map<SalidaResponse>(salida);
        }

        public async Task<List<SalidaResponse>> GetAllSalidas(int inventarioId)
        {
            var salidas = await _inventarioRepository.GetAllSalidas(inventarioId);
            return _mapper.Map<List<SalidaResponse>>(salidas);
        }
        #endregion

    }
}
