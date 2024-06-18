using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.Insumos;
using IRepository.Schema_Almacen.Insumos;
using Repository.Schema_Almacen.Insumos;
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
        private readonly IMapper _mapper;
        public InsumoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _insumoRepository = new InsumoRepository();
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
    }
}
