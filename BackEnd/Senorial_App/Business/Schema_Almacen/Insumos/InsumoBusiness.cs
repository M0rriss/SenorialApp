using AutoMapper;
using Business.Schema_Almacen.DetalleInventarios;
using CommonModels.Common;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.DetalleInventarios;
using IBusiness.Schema_Almacen.Insumos;
using IRepository.Schema_Almacen.Insumos;
using IRepository.Schema_Generico.UnidadMediciones;
using Repository.Schema_Almacen.Insumos;
using Repository.Schema_Generico.UnidadMediciones;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.Insumos
{
    public class InsumoBusiness : IInsumoBusiness
    {
        #region Dependency Injecction
        private readonly IInsumoRepository _insumoRepository;
        private readonly IDetalleInventarioBusiness _detalleInventarioBusiness;
        private readonly IUnidadMedicionRepository _unidadMedicionRepository;
        private readonly IMapper _mapper;
        public InsumoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _detalleInventarioBusiness = new DetalleInventarioBusiness();
            _insumoRepository = new InsumoRepository();
            _unidadMedicionRepository = new UnidadMedicionRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<InsumoResponse>> GetAll()
        {
            List<Insumo> insumo = await _insumoRepository.GetAll();
            var response = _mapper.Map<List<InsumoResponse>>(insumo);
            return response;
        }
        public async Task<InsumoResponse> GetById(int id)
        {
            var insumo = await _insumoRepository.GetById(id);
            var response = _mapper.Map<InsumoResponse>(insumo);
            return response;
        }

        public async Task<InsumoResponse> Create(InsumoRequest entity)
        {
            var insumo = _mapper.Map<Insumo>(entity);
            insumo = await _insumoRepository.Create(insumo);
            var response = _mapper.Map<InsumoResponse>(insumo);
            return response;
        }

        public async Task<List<InsumoResponse>> CreateMultiple(List<InsumoRequest> list)
        {
            var insumo = _mapper.Map<List<Insumo>>(list);
            insumo = await _insumoRepository.CreateMultiple(insumo);
            var response = _mapper.Map<List<InsumoResponse>>(insumo);
            return response;
        }

        public async Task<InsumoResponse> Update(InsumoRequest entity)
        {
            var insumo = _mapper.Map<Insumo>(entity);
            insumo = await _insumoRepository.Update(insumo);
            var response = _mapper.Map<InsumoResponse>(insumo);
            return response; ;
        }

        public async Task<List<InsumoResponse>> UpdateMultiple(List<InsumoRequest> list)
        {
            var insumo = _mapper.Map<List<Insumo>>(list);
            insumo = await _insumoRepository.UpdateMultiple(insumo);
            var response = _mapper.Map<List<InsumoResponse>>(insumo);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _insumoRepository.Delete(id);
            return result;
        }

        public async Task<List<InsumoRequest>> DeleteMultiple(List<InsumoRequest> list)
        {
            var insumo = _mapper.Map<List<Insumo>>(list);
            var deletedCount = await _insumoRepository.DeleteMultiple(insumo);
            return list;

        }

        public async Task<GenericFilterResponse<InsumoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _insumoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<InsumoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _insumoRepository.Dispose();
        }

        #endregion
        #region UI CRUD
        public async Task<List<InsumoUiRequest>> UiGetInsumo()
        {
            return await _insumoRepository.UiInsumo();
        }

        public async Task<InsumoUiResponse> InsertUiInsumo(InsumoUiRequest request)
        {
            var existingNombre = await _insumoRepository.BuscarNombre(request.InsumoNombre);
            if (existingNombre != null)
            {
                throw new ArgumentException("El nombre del insumo ya está registrado.");
            }

            var unidadMedida = await _unidadMedicionRepository.ObtenerUnidadMedidaPorNombre(request.UnidadMedida);
            if (unidadMedida == null)
            {
                throw new ArgumentException("La unidad de medida especificada no existe.");
            }

            var insumo = new Insumo
            {
                Nombre = request.InsumoNombre,
                IdUnidad = unidadMedida.IdUnidad
            };

            var insumoCreado = await _insumoRepository.Create(insumo);
            var response = _mapper.Map<InsumoUiResponse>(insumoCreado);
            response.UnidadMedida = unidadMedida.Abreviacion;
            return response;
        }

        public async Task<InsumoUiResponse> UpdateUiInsumo(InsumoUpdateUiRequest request)
        {
            var existingInsumo = await _insumoRepository.BuscarporId(request.IdInsumo);
            if (existingInsumo == null)
            {
                throw new ArgumentException(nameof(existingInsumo), "Insumo no encontrado");
            }

            var existingNombre = await _insumoRepository.BuscarNombre(request.InsumoNombre);
            if (existingNombre != null && existingNombre.IdInsumo != existingInsumo.IdInsumo)
            {
                throw new ArgumentException("El nombre del insumo ya está registrado.");
            }

            var unidadMedida = await _unidadMedicionRepository.ObtenerUnidadMedidaPorNombre(request.UnidadMedida);
            if (unidadMedida == null)
            {
                throw new ArgumentException("La unidad de medida especificada no existe.");
            }

            existingInsumo.Nombre = request.InsumoNombre;
            existingInsumo.IdUnidad = unidadMedida.IdUnidad;

            var insumoActualizado = await _insumoRepository.Update(existingInsumo);
            var response = _mapper.Map<InsumoUiResponse>(insumoActualizado);
            response.UnidadMedida = unidadMedida.Abreviacion;

            return response;
        }

        public async Task<bool> DeleteUiInsumo(int idInsumo)
        {
            var insumo = await _insumoRepository.GetById(idInsumo);
            if (insumo == null)
            {
                throw new ArgumentNullException(nameof(insumo), "Insumo no encontrado");
            }

            await _insumoRepository.Delete(idInsumo);
            return true;
        }
        #endregion

        #region Personalizado
        public async Task<GenericFilterResponse<InsumoUiRequest>> FiltroInsumoAsync(GenericFilterRequest req)
        {
            return await _insumoRepository.GetByFilterViewAsync(req);
        }
        public async Task<CustomResponse> CrearInsumoAsync(InsumoRequest req)
        {
            Insumo insumo = new()
            {
                Nombre = req.Nombre,
                Url = req.Url,
                IdUnidad = req.IdUnidad,
            };
            insumo = await _insumoRepository.Create(insumo);
            DetalleInventarioRequest detalle = new()
            {
                IdInsumo = insumo.IdInsumo,
                IdInventario = 1,
                StockTotal = 0,
            };
            await _detalleInventarioBusiness.Create(detalle);
            CustomResponse response = new CustomResponse();
            response.Message = "Registro Correctamente";
            response.Code = "2000";
            return response;
        }
        public async Task<CustomResponse> ActulizarInsumoAsync(InsumoRequest req)
        {
            Insumo insumo = new()
            {
                IdInsumo = req.IdInsumo,
                Nombre = req.Nombre,
                Url = req.Url,
                IdUnidad = req.IdUnidad,
            };
            insumo = await _insumoRepository.Update(insumo);
            CustomResponse response = new CustomResponse();
            response.Message = "Actulizar Correctamente";
            response.Code = "2000";
            return response;
        }
        #endregion Personalizado
    }
}
