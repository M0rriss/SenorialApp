using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Productos;
using IRepository.Schema_Ventas.Productos;
using Repository.Schema_Ventas.Productos;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Productos
{
    public class ProductoBusiness : IProductoBusiness
    {
        #region Dependency Injecction
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _productoRepository = new ProductoRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<ProductoResponse>> GetAll()
        {
            List<Producto> producto = await _productoRepository.GetAll();
            var response = _mapper.Map<List<ProductoResponse>>(producto);
            return response;
        }
        public async Task<ProductoResponse> GetById(int id)
        {
            Producto producto = await _productoRepository.GetById(id);
            var response = _mapper.Map<ProductoResponse>(producto);
            return response;
        }

        public async Task<ProductoResponse> Create(ProductoRequest entity)
        {
            Producto producto = _mapper.Map<Producto>(entity);
            producto = await _productoRepository.Create(producto);
            var response = _mapper.Map<ProductoResponse>(producto);
            return response;
        }

        public async Task<List<ProductoResponse>> CreateMultiple(List<ProductoRequest> list)
        {
            var producto = _mapper.Map<List<Producto>>(list);
            producto = await _productoRepository.CreateMultiple(producto);
            var response = _mapper.Map<List<ProductoResponse>>(producto);
            return response;
        }

        public async Task<ProductoResponse> Update(ProductoRequest entity)
        {
            var producto = _mapper.Map<Producto>(entity);
            producto = await _productoRepository.Update(producto);
            var response = _mapper.Map<ProductoResponse>(producto);
            return response; ;
        }

        public async Task<List<ProductoResponse>> UpdateMultiple(List<ProductoRequest> list)
        {
            var producto = _mapper.Map<List<Producto>>(list);
            producto = await _productoRepository.UpdateMultiple(producto);
            var response = _mapper.Map<List<ProductoResponse>>(producto);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _productoRepository.Delete(id);
            return result;
        }

        public async Task<List<ProductoRequest>> DeleteMultiple(List<ProductoRequest> list)
        {
            var producto = _mapper.Map<List<Producto>>(list);
            var deletedCount = await _productoRepository.DeleteMultiple(producto);
            return list;

        }

        public async Task<GenericFilterResponse<ProductoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _productoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<ProductoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _productoRepository.Dispose();
        }

        #endregion
    }
}
