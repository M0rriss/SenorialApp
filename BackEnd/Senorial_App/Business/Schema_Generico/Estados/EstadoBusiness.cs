using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Generico.Estados;
using IRepository.Schema_Generico.Estados;
using Repository.Schema_Generico.Estados;
using RequestResponseModels.Request.Schema_Generico.Estado;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Estado;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Generico.Estados
{
    public class EstadoBusiness : IEstadoBusiness
    {
        #region Dependency Injecction
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;
        public EstadoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _estadoRepository = new EstadoRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<EstadoResponse>> GetAll()
        {
            List<Estado> estado = await _estadoRepository.GetAll();
            var response = _mapper.Map<List<EstadoResponse>>(estado);
            return response;
        }
        public async Task<EstadoResponse> GetById(int id)
        {
            var estado = await _estadoRepository.GetById(id);
            var response = _mapper.Map<EstadoResponse>(estado);
            return response;
        }

        public async Task<EstadoResponse> Create(EstadoRequest entity)
        {
            var estado = _mapper.Map<Estado>(entity);
            estado = await _estadoRepository.Create(estado);
            var response = _mapper.Map<EstadoResponse>(estado);
            return response;
        }

        public async Task<List<EstadoResponse>> CreateMultiple(List<EstadoRequest> list)
        {
            var estado = _mapper.Map<List<Estado>>(list);
            estado = await _estadoRepository.CreateMultiple(estado);
            var response = _mapper.Map<List<EstadoResponse>>(estado);
            return response;
        }

        public async Task<EstadoResponse> Update(EstadoRequest entity)
        {
            var estado = _mapper.Map<Estado>(entity);
            estado = await _estadoRepository.Update(estado);
            var response = _mapper.Map<EstadoResponse>(estado);
            return response; ;
        }

        public async Task<List<EstadoResponse>> UpdateMultiple(List<EstadoRequest> list)
        {
            var estado = _mapper.Map<List<Estado>>(list);
            estado = await _estadoRepository.UpdateMultiple(estado);
            var response = _mapper.Map<List<EstadoResponse>>(estado);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _estadoRepository.Delete(id);
            return result;
        }

        public async Task<List<EstadoRequest>> DeleteMultiple(List<EstadoRequest> list)
        {
            var estado = _mapper.Map<List<Estado>>(list);
            var deletedCount = await _estadoRepository.DeleteMultiple(estado);
            return list;

        }

        public async Task<GenericFilterResponse<EstadoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _estadoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<EstadoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _estadoRepository.Dispose();
        }

        #endregion
    }
}
