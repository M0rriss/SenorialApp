using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.TipoPedido;
using IRepository.Schema_Ventas.TipoPedidos;
using Repository.Schema_Ventas.TipoPedidos;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.TipoPedido;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.TipoPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.TipoPedidos
{
    public class TipoPedidoBusiness : ITipoPedidoBusiness
    {
        #region Dependency Injecction
        private readonly ITipoPedidoRepository _TipoPedidoRepository;
        private readonly IMapper _mapper;
        public TipoPedidoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _TipoPedidoRepository = new TipoPedidoRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<TipoPedidoResponse>> GetAll()
        {
            List<TipoPedido> TipoPedido = await _TipoPedidoRepository.GetAll();
            var response = _mapper.Map<List<TipoPedidoResponse>>(TipoPedido);
            return response;
        }
        public async Task<TipoPedidoResponse> GetById(int id)
        {
            var TipoPedido = await _TipoPedidoRepository.GetById(id);
            var response = _mapper.Map<TipoPedidoResponse>(TipoPedido);
            return response;
        }

        public async Task<TipoPedidoResponse> Create(TipoPedidoRequest entity)
        {
            var TipoPedido = _mapper.Map<TipoPedido>(entity);
            TipoPedido = await _TipoPedidoRepository.Create(TipoPedido);
            var response = _mapper.Map<TipoPedidoResponse>(TipoPedido);
            return response;
        }

        public async Task<List<TipoPedidoResponse>> CreateMultiple(List<TipoPedidoRequest> list)
        {
            var TipoPedido = _mapper.Map<List<TipoPedido>>(list);
            TipoPedido = await _TipoPedidoRepository.CreateMultiple(TipoPedido);
            var response = _mapper.Map<List<TipoPedidoResponse>>(TipoPedido);
            return response;
        }

        public async Task<TipoPedidoResponse> Update(TipoPedidoRequest entity)
        {
            var TipoPedido = _mapper.Map<TipoPedido>(entity);
            TipoPedido = await _TipoPedidoRepository.Update(TipoPedido);
            var response = _mapper.Map<TipoPedidoResponse>(TipoPedido);
            return response; ;
        }

        public async Task<List<TipoPedidoResponse>> UpdateMultiple(List<TipoPedidoRequest> list)
        {
            var TipoPedido = _mapper.Map<List<TipoPedido>>(list);
            TipoPedido = await _TipoPedidoRepository.UpdateMultiple(TipoPedido);
            var response = _mapper.Map<List<TipoPedidoResponse>>(TipoPedido);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _TipoPedidoRepository.Delete(id);
            return result;
        }

        public async Task<List<TipoPedidoRequest>> DeleteMultiple(List<TipoPedidoRequest> list)
        {
            var TipoPedido = _mapper.Map<List<TipoPedido>>(list);
            var deletedCount = await _TipoPedidoRepository.DeleteMultiple(TipoPedido);
            return list;

        }

        public async Task<GenericFilterResponse<TipoPedidoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _TipoPedidoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<TipoPedidoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _TipoPedidoRepository.Dispose();
        }

        #endregion
    }
}
