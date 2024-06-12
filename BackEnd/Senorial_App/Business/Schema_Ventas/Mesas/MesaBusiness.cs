using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Mesas;
using IRepository.Schema_Ventas.Mesas;
using Repository.Schema_Ventas.Mesas;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Mesas;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Mesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Mesas
{
    public class MesaBusiness : IMesaBusiness
    {
        #region Dependency Injecction
        private readonly IMesaRepository _mesaRepository;
        private readonly IMapper _mapper;
        public MesaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _mesaRepository = new MesaRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<MesaResponse>> GetAll()
        {
            List<Mesa> mesa = await _mesaRepository.GetAll();
            var response = _mapper.Map<List<MesaResponse>>(mesa);
            return response;
        }
        public async Task<MesaResponse> GetById(int id)
        {
            Mesa mesa = await _mesaRepository.GetById(id);
            var response = _mapper.Map<MesaResponse>(mesa);
            return response;
        }

        public async Task<MesaResponse> Create(MesaRequest entity)
        {
            Mesa mesa = _mapper.Map<Mesa>(entity);
            mesa = await _mesaRepository.Create(mesa);
            var response = _mapper.Map<MesaResponse>(mesa);
            return response;
        }

        public async Task<List<MesaResponse>> CreateMultiple(List<MesaRequest> list)
        {
            var mesa = _mapper.Map<List<Mesa>>(list);
            mesa = await _mesaRepository.CreateMultiple(mesa);
            var response = _mapper.Map<List<MesaResponse>>(mesa);
            return response;
        }

        public async Task<MesaResponse> Update(MesaRequest entity)
        {
            var mesa = _mapper.Map<Mesa>(entity);
            mesa = await _mesaRepository.Update(mesa);
            var response = _mapper.Map<MesaResponse>(mesa);
            return response; ;
        }

        public async Task<List<MesaResponse>> UpdateMultiple(List<MesaRequest> list)
        {
            var mesa = _mapper.Map<List<Mesa>>(list);
            mesa = await _mesaRepository.UpdateMultiple(mesa);
            var response = _mapper.Map<List<MesaResponse>>(mesa);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _mesaRepository.Delete(id);
            return result;
        }

        public async Task<List<MesaRequest>> DeleteMultiple(List<MesaRequest> list)
        {
            var mesa = _mapper.Map<List<Mesa>>(list);
            var deletedCount = await _mesaRepository.DeleteMultiple(mesa);
            return list;

        }

        public async Task<GenericFilterResponse<MesaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _mesaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<MesaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _mesaRepository.Dispose();
        }

        #endregion

    }
}
