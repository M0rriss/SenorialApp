using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Generico.UnidadMediciones;
using IRepository.Schema_Generico.UnidadMediciones;
using Repository.Schema_Generico.UnidadMediciones;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Generico.UnidadMedicion;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.UnidadMedicion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Generico.UnidadMediciones
{
    public class UnidadMedicionBusiness: IUnidadMedicionBusiness
    {
        #region Dependency Injecction
        private readonly IUnidadMedicionRepository _unidadMedicionRepository;
        private readonly IMapper _mapper;
        public UnidadMedicionBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _unidadMedicionRepository = new UnidadMedicionRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<UnidadMedicionResponse>> GetAll()
        {
            List<UnidadMedicion> unidadMedicion = await _unidadMedicionRepository.GetAll();
            var response = _mapper.Map<List<UnidadMedicionResponse>>(unidadMedicion);
            return response;
        }
        public async Task<UnidadMedicionResponse> GetById(int id)
        {
            UnidadMedicion unidadMedicion = await _unidadMedicionRepository.GetById(id);
            var response = _mapper.Map<UnidadMedicionResponse>(unidadMedicion);
            return response;
        }

        public async Task<UnidadMedicionResponse> Create(UnidadMedicionRequest entity)
        {
            UnidadMedicion unidadMedicion = _mapper.Map<UnidadMedicion>(entity);
            unidadMedicion = await _unidadMedicionRepository.Create(unidadMedicion);
            var response = _mapper.Map<UnidadMedicionResponse>(unidadMedicion);
            return response;
        }

        public async Task<List<UnidadMedicionResponse>> CreateMultiple(List<UnidadMedicionRequest> list)
        {
            var unidadMedicion = _mapper.Map<List<UnidadMedicion>>(list);
            unidadMedicion = await _unidadMedicionRepository.CreateMultiple(unidadMedicion);
            var response = _mapper.Map<List<UnidadMedicionResponse>>(unidadMedicion);
            return response;
        }

        public async Task<UnidadMedicionResponse> Update(UnidadMedicionRequest entity)
        {
            var unidadMedicion = _mapper.Map<UnidadMedicion>(entity);
            unidadMedicion = await _unidadMedicionRepository.Update(unidadMedicion);
            var response = _mapper.Map<UnidadMedicionResponse>(unidadMedicion);
            return response; ;
        }

        public async Task<List<UnidadMedicionResponse>> UpdateMultiple(List<UnidadMedicionRequest> list)
        {
            var unidadMedicion = _mapper.Map<List<UnidadMedicion>>(list);
            unidadMedicion = await _unidadMedicionRepository.UpdateMultiple(unidadMedicion);
            var response = _mapper.Map<List<UnidadMedicionResponse>>(unidadMedicion);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _unidadMedicionRepository.Delete(id);
            return result;
        }

        public async Task<List<UnidadMedicionRequest>> DeleteMultiple(List<UnidadMedicionRequest> list)
        {
            var unidadMedicion = _mapper.Map<List<UnidadMedicion>>(list);
            var deletedCount = await _unidadMedicionRepository.DeleteMultiple(unidadMedicion);
            return list;

        }

        public async Task<GenericFilterResponse<UnidadMedicionResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _unidadMedicionRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<UnidadMedicionResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _unidadMedicionRepository.Dispose();
        }

        #endregion
    }
}
