using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.MetodoPago;
using IRepository.Schema_Ventas.MetodoPagos;
using Repository.Schema_Ventas.MetodoPagos;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.MetodoPago;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RequestResponseModels.Request.Schema_Ventas.MetodoPago.MetodoPagoRequest;

namespace Business.Schema_Ventas.MetodoPagos
{
    public class MetodoPagoBusiness : IMetodoPagoBusiness
    {
        #region Dependency Injecction
        private readonly IMetodoPagoRepository _metodoPagoRepository;
        private readonly IMapper _mapper;
        public MetodoPagoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _metodoPagoRepository = new MetodoPagoRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<MetodoPagoResponse>> GetAll()
        {
            List<MetodoPago> metodoPago = await _metodoPagoRepository.GetAll();
            var response = _mapper.Map<List<MetodoPagoResponse>>(metodoPago);
            return response;
        }
        public async Task<MetodoPagoResponse> GetById(int id)
        {
            var metodoPago = await _metodoPagoRepository.GetById(id);
            var response = _mapper.Map<MetodoPagoResponse>(metodoPago);
            return response;
        }

        public async Task<MetodoPagoResponse> Create(MetodoPagoRequest entity)
        {
            var metodoPago = _mapper.Map<MetodoPago>(entity);
            metodoPago = await _metodoPagoRepository.Create(metodoPago);
            var response = _mapper.Map<MetodoPagoResponse>(metodoPago);
            return response;
        }

        public async Task<List<MetodoPagoResponse>> CreateMultiple(List<MetodoPagoRequest> list)
        {
            var metodoPago = _mapper.Map<List<MetodoPago>>(list);
            metodoPago = await _metodoPagoRepository.CreateMultiple(metodoPago);
            var response = _mapper.Map<List<MetodoPagoResponse>>(metodoPago);
            return response;
        }

        public async Task<MetodoPagoResponse> Update(MetodoPagoRequest entity)
        {
            var metodoPago = _mapper.Map<MetodoPago>(entity);
            metodoPago = await _metodoPagoRepository.Update(metodoPago);
            var response = _mapper.Map<MetodoPagoResponse>(metodoPago);
            return response; ;
        }

        public async Task<List<MetodoPagoResponse>> UpdateMultiple(List<MetodoPagoRequest> list)
        {
            var metodoPago = _mapper.Map<List<MetodoPago>>(list);
            metodoPago = await _metodoPagoRepository.UpdateMultiple(metodoPago);
            var response = _mapper.Map<List<MetodoPagoResponse>>(metodoPago);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _metodoPagoRepository.Delete(id);
            return result;
        }

        public async Task<List<MetodoPagoRequest>> DeleteMultiple(List<MetodoPagoRequest> list)
        {
            var metodoPago = _mapper.Map<List<MetodoPago>>(list);
            var deletedCount = await _metodoPagoRepository.DeleteMultiple(metodoPago);
            return list;

        }

        public async Task<GenericFilterResponse<MetodoPagoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _metodoPagoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<MetodoPagoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _metodoPagoRepository.Dispose();
        }

        #endregion
        #region UI Methods
        public async Task<List<MetodoPagoUiResponse>> UiGetMetodoPago()
        {
            return await _metodoPagoRepository.UiMetodoPago();
        }

        public async Task<MetodoPagoUiResponse> InsertUiMetodoPago(MetodoPagoUiRequest request)
        {
            var existingMetodo = await _metodoPagoRepository.BuscarNombre(request.Descripcion);
            if (existingMetodo != null)
            {
                throw new ArgumentException("El método de pago ya está registrado.");
            }

            var metodoPago = _mapper.Map<MetodoPago>(request);
            var metodoPagoCreado = await _metodoPagoRepository.Create(metodoPago);
            var response = _mapper.Map<MetodoPagoUiResponse>(metodoPagoCreado);
            return response;
        }

        public async Task<MetodoPagoUiResponse> UpdateUiMetodoPago(MetodoPagoUpdateUiRequest request)
        {
            var existingMetodo = await _metodoPagoRepository.GetById(request.IdMetodo);
            if (existingMetodo == null)
            {
                throw new ArgumentException("El método de pago especificado no existe.");
            }

            _mapper.Map(request, existingMetodo);
            await _metodoPagoRepository.Update(existingMetodo);
            var response = _mapper.Map<MetodoPagoUiResponse>(existingMetodo);
            return response;
        }

        public async Task<bool> DeleteUiMetodoPago(int id)
        {
            var metodoPago = await _metodoPagoRepository.GetById(id);
            if (metodoPago == null)
            {
                throw new ArgumentException("El método de pago especificado no existe.");
            }

            await _metodoPagoRepository.Delete(id);
            return true;
        }
        #endregion

    }


}
