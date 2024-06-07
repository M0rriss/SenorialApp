using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.Categorias;
using IRepository.Schema_Almacen.Categorias;
using Repository.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.Categorias
{
    public class CategoriaBusiness : ICategoriaBusiness
    {
        #region Dependency Injecction
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepository = new CategoriaRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<CategoriaResponse>> GetAll()
        {
            List<Categoria> categoria = await _categoriaRepository.GetAll();
            var response = _mapper.Map<List<CategoriaResponse>>(categoria);
            return response;
        }
        public async Task<CategoriaResponse> GetById(int id)
        {
            Categoria categoria = await _categoriaRepository.GetById(id);
            var response = _mapper.Map<CategoriaResponse>(categoria);
            return response;
        }

        public async Task<CategoriaResponse> Create(CategoriaRequest entity)
        {
            Categoria categoria = _mapper.Map<Categoria>(entity);
            categoria = await _categoriaRepository.Create(categoria);
            var response = _mapper.Map<CategoriaResponse>(categoria);
            return response;
        }

        public async Task<List<CategoriaResponse>> CreateMultiple(List<CategoriaRequest> list)
        {
            var categoria = _mapper.Map<List<Categoria>>(list);
            categoria = await _categoriaRepository.CreateMultiple(categoria);
            var response = _mapper.Map<List<CategoriaResponse>>(categoria);
            return response;
        }

        public async Task<CategoriaResponse> Update(CategoriaRequest entity)
        {
            var categoria = _mapper.Map<Categoria>(entity);
            categoria = await _categoriaRepository.Update(categoria);
            var response = _mapper.Map<CategoriaResponse>(categoria);
            return response; ;
        }

        public async Task<List<CategoriaResponse>> UpdateMultiple(List<CategoriaRequest> list)
        {
            var categoria = _mapper.Map<List<Categoria>>(list);
            categoria = await _categoriaRepository.UpdateMultiple(categoria);
            var response = _mapper.Map<List<CategoriaResponse>>(categoria);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _categoriaRepository.Delete(id);
            return result;
        }

        public async Task<List<CategoriaRequest>> DeleteMultiple(List<CategoriaRequest> list)
        {
            var categoria = _mapper.Map<List<Categoria>>(list);
            var deletedCount = await _categoriaRepository.DeleteMultiple(categoria);
            return list;
         
        }

        //public async Task<ResponseFilterGeneric<CategoriaResponse>> GetByFilter(RequestFilterGeneric request)
        //{
        //    var filtro = await _categoriaRepository.GetByFilter(request);
        //    var result = _mapper.Map<ResponseFilterGeneric<CategoriaResponse>>(filtro);
        //    return result;
        //}

        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }
        #endregion
    }
}
