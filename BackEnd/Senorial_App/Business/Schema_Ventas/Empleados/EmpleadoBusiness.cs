using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Empleados;
using IRepository.Schema_Ventas.Empleados;
using Repository.Schema_Ventas.Empleados;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Empleados
{
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        #region Dependency Injecction
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;
        public EmpleadoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _empleadoRepository = new EmpleadoRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<EmpleadoResponse>> GetAll()
        {
            List<Empleado> empleado = await _empleadoRepository.GetAll();
            var response = _mapper.Map<List<EmpleadoResponse>>(empleado);
            return response;
        }
        public async Task<EmpleadoResponse> GetById(int id)
        {
            Empleado empleado = await _empleadoRepository.GetById(id);
            var response = _mapper.Map<EmpleadoResponse>(empleado);
            return response;
        }

        public async Task<EmpleadoResponse> Create(EmpleadoRequest entity)
        {
            Empleado empleado = _mapper.Map<Empleado>(entity);
            empleado = await _empleadoRepository.Create(empleado);
            var response = _mapper.Map<EmpleadoResponse>(empleado);
            return response;
        }

        public async Task<List<EmpleadoResponse>> CreateMultiple(List<EmpleadoRequest> list)
        {
            var empleado = _mapper.Map<List<Empleado>>(list);
            empleado = await _empleadoRepository.CreateMultiple(empleado);
            var response = _mapper.Map<List<EmpleadoResponse>>(empleado);
            return response;
        }

        public async Task<EmpleadoResponse> Update(EmpleadoRequest entity)
        {
            var empleado = _mapper.Map<Empleado>(entity);
            empleado = await _empleadoRepository.Update(empleado);
            var response = _mapper.Map<EmpleadoResponse>(empleado);
            return response; ;
        }

        public async Task<List<EmpleadoResponse>> UpdateMultiple(List<EmpleadoRequest> list)
        {
            var empleado = _mapper.Map<List<Empleado>>(list);
            empleado = await _empleadoRepository.UpdateMultiple(empleado);
            var response = _mapper.Map<List<EmpleadoResponse>>(empleado);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _empleadoRepository.Delete(id);
            return result;
        }

        public async Task<List<EmpleadoRequest>> DeleteMultiple(List<EmpleadoRequest> list)
        {
            var empleado = _mapper.Map<List<Empleado>>(list);
            var deletedCount = await _empleadoRepository.DeleteMultiple(empleado);
            return list;

        }

        public async Task<GenericFilterResponse<EmpleadoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _empleadoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<EmpleadoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _empleadoRepository.Dispose();
        }

        public List<EmpleadoUiRequest> UiGetEmpleado()
        {
            return _empleadoRepository.UiEmpleado();
        }

        #endregion
    }
}
