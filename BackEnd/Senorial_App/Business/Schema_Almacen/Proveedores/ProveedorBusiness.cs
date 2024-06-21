using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Almacen.Proveedores;
using IRepository.Schema_Almacen.Proveedores;
using Repository.Schema_Almacen.Proveedores;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Almacen.Proveedores
{
    public class ProveedorBusiness : IProveedorBusiness
    {
        #region Dependency Injecction
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;
        public ProveedorBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _proveedorRepository = new ProveedorRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<ProveedorResponse>> GetAll()
        {
            List<Proveedor> proveedor = await _proveedorRepository.GetAll();
            var response = _mapper.Map<List<ProveedorResponse>>(proveedor);
            return response;
        }
        public async Task<ProveedorResponse> GetById(int id)
        {
            Proveedor proveedor = await _proveedorRepository.GetById(id);
            var response = _mapper.Map<ProveedorResponse>(proveedor);
            return response;
        }

        public async Task<ProveedorResponse> Create(ProveedorRequest entity)
        {
            Proveedor proveedor = _mapper.Map<Proveedor>(entity);
            proveedor = await _proveedorRepository.Create(proveedor);
            var response = _mapper.Map<ProveedorResponse>(proveedor);
            return response;
        }

        public async Task<List<ProveedorResponse>> CreateMultiple(List<ProveedorRequest> list)
        {
            var proveedor = _mapper.Map<List<Proveedor>>(list);
            proveedor = await _proveedorRepository.CreateMultiple(proveedor);
            var response = _mapper.Map<List<ProveedorResponse>>(proveedor);
            return response;
        }

        public async Task<ProveedorResponse> Update(ProveedorRequest entity)
        {
            var proveedor = _mapper.Map<Proveedor>(entity);
            proveedor = await _proveedorRepository.Update(proveedor);
            var response = _mapper.Map<ProveedorResponse>(proveedor);
            return response; ;
        }

        public async Task<List<ProveedorResponse>> UpdateMultiple(List<ProveedorRequest> list)
        {
            var proveedor = _mapper.Map<List<Proveedor>>(list);
            proveedor = await _proveedorRepository.UpdateMultiple(proveedor);
            var response = _mapper.Map<List<ProveedorResponse>>(proveedor);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _proveedorRepository.Delete(id);
            return result;
        }

        public async Task<List<ProveedorRequest>> DeleteMultiple(List<ProveedorRequest> list)
        {
            var Proveedor = _mapper.Map<List<Proveedor>>(list);
            var deletedCount = await _proveedorRepository.DeleteMultiple(Proveedor);
            return list;

        }

        public async Task<GenericFilterResponse<ProveedorResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _proveedorRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<ProveedorResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _proveedorRepository.Dispose();
        }

        #endregion
        public List<ProveedorUiRequest> UiGetProveedor()
        {
            return _proveedorRepository.UiProveedor();
        }
    }
}
