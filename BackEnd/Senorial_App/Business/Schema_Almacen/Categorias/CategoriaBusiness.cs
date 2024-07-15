using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.Categorias;
using IRepository.Schema_Almacen.Categorias;
using Repository.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RequestResponseModels.Response.Schema_Almacen.Categorias.CategoriaResponse;

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

        public async Task<GenericFilterResponse<CategoriaResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _categoriaRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<CategoriaResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }

        #endregion
        #region UI CRUD
        public async Task<List<CategoriaUiRequest>> UiGetCategoria()
        {
            return await _categoriaRepository.UiCategoria();
        }

        public async Task<CategoriaUiResponse> InsertUiCategoria(CategoriaUiRequest request)
        {
            // Buscar categoría existente por nombre
            var existingCategoria = await _categoriaRepository.BuscarPorNombre(request.Categoria);
            if (existingCategoria != null)
            {
                throw new ArgumentException("La categoría ya está registrada.");
            }

            // Buscar subcategoría existente por nombre si se proporciona
            Categoria subcategoria = null;
            if (!string.IsNullOrEmpty(request.Subcategorias))
            {
                subcategoria = await _categoriaRepository.BuscarPorNombre(request.Subcategorias);
                if (subcategoria == null)
                {
                    throw new ArgumentException("La subcategoría especificada no existe.");
                }
            }

            // Realiza la conversión manual de Estado y asigna la subcategoría si existe
            var categoria = new Categoria
            {
                Nombre = request.Categoria,
                Estado = ConvertToBoolean(request.Estado),
                CategoriaPadre = subcategoria
            };

            var categoriaCreada = await _categoriaRepository.Create(categoria);

            // Mapear la respuesta
            var response = new CategoriaUiResponse
            {
                Categoria = categoriaCreada.Nombre,
                Estado = categoriaCreada.Estado ? "Activo" : "Inactivo",
                Subcategorias = categoriaCreada.CategoriaPadre?.Nombre
            };
            return response;
        }

        public async Task<CategoriaUiResponse> UpdateUiCategoria(CategoriaUpdateUiRequest request)
        {
            //var existingCategoria = await _categoriaRepository.GetById(request.IdCategoria);
            //if (existingCategoria == null)
            //{
            //    throw new ArgumentException("La categoría especificada no existe.");
            //}

            //_mapper.Map(request, existingCategoria);
            //await _categoriaRepository.Update(existingCategoria);
            //var response = _mapper.Map<CategoriaUiResponse>(existingCategoria);
            //return response;
            // Buscar la categoría existente por Id
            var existingCategoria = await _categoriaRepository.GetById(request.IdCategoria);
            if (existingCategoria == null)
            {
                throw new ArgumentException("La categoría especificada no existe.");
            }

            // Buscar la categoría padre por nombre si se proporciona
            Categoria categoriaPadre = null;
            if (request.IdCategoriaPadre.HasValue)
            {
                categoriaPadre = await _categoriaRepository.GetById(request.IdCategoriaPadre.Value);
                if (categoriaPadre == null)
                {
                    throw new ArgumentException("La categoría padre especificada no existe.");
                }
            }

            // Actualizar los datos de la categoría existente
            existingCategoria.Nombre = request.Nombre;
            existingCategoria.Estado = request.Estado;
            existingCategoria.CategoriaPadre = categoriaPadre;

            // Guardar los cambios en la base de datos
            await _categoriaRepository.Update(existingCategoria);

            // Mapear la respuesta
            var response = new CategoriaUiResponse
            {
                Categoria = existingCategoria.Nombre,
                Estado = existingCategoria.Estado ? "Activo" : "Inactivo",
                Subcategorias = existingCategoria.CategoriaPadre?.Nombre
            };

            return response;
        }

        public async Task<bool> DeleteUiCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                throw new ArgumentException("La categoría especificada no existe.");
            }

            await _categoriaRepository.Delete(id);
            return true;
        }
        private bool ConvertToBoolean(string estado)
        {
            return !string.IsNullOrEmpty(estado) && estado.Equals("Activo", StringComparison.OrdinalIgnoreCase);
        }
        #endregion
    }
}
