using AutoMapper;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Office2010.Excel;
using IBusiness.Schema_Ventas.Empleados;
using IRepository.Schema_Generico.Sucursales;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Roles;
using IRepository.Schema_Ventas.Empleados;
using Repository.Schema_Generico.Sucursales;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Roles;
using Repository.Schema_Ventas.Empleados;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
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
        private readonly IPersonaRepository _personaRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;
        public EmpleadoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _empleadoRepository = new EmpleadoRepository();
            _personaRepository = new PersonaRepository();
            _rolesRepository = new RolesRepository();
            _sucursalRepository = new SucursalRepository();
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
        #endregion
        #region CRUD PERSONALIZADO
        public async Task<List<EmpleadosUiRequest>> UiGetEmpleado()
        {
            var empleados = await _empleadoRepository.UiEmpleado();
            return empleados; 
        }

        public async Task<EmpleadosUiResponse> InsertUiEmpleado(EmpleadosUiRequest request)
        {
            // Check if the email is already in use
            var existingPersonaByEmail = _personaRepository.BuscarCorreo(request.Correo);
            if (existingPersonaByEmail != null)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }

            // Check if the phone number is already in use
            var existingPersonaByPhone = _personaRepository.BuscarTelefono(request.Telefono);
            if (existingPersonaByPhone != null)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }

            // Split names and last names
            var nombres = request.Nombres.Split(' ', 2);
            var apellidos = request.Apellidos.Split(' ', 2);

            var persona = new Persona
            {
                PrimerNombre = nombres[0], // Primer nombre
                SegundoNombre = nombres.Length > 1 ? nombres[1] : null, // Segundo nombre (if exists)
                ApellidoPaterno = apellidos[0], // Apellido paterno
                ApellidoMaterno = apellidos.Length > 1 ? apellidos[1] : null, // Apellido materno (if exists)
                Email = request.Correo.ToLower(),
                Telefono = request.Telefono,
                NroDocumento = request.Identificacion,
                Genero = "",
                IdTipoDocumento = 1
            };

            await _personaRepository.Create(persona);

            var sucursal = await _sucursalRepository.GetBySucursalName(request.Sucursal);
            if (sucursal == null)
            {
                throw new ArgumentException("La sucursal especificada no existe.");
            }

            var rol = await _rolesRepository.GetByRol(request.Rol);
            if (rol == null)
            {
                throw new ArgumentException("El rol especificado no existe.");
            }

            var estado = request.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) ? true : request.Estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase) ? false : (bool?)null;

            var empleado = new Empleado
            {
                IdPersona = persona.IdPersona,
                IdRol = rol.IdRol,
                IdSucursal = sucursal.IdSucursal,
                Estado = estado
            };

            // Insert the new Empleado
            await _empleadoRepository.Create(empleado);

            // Map the inserted entity back to the response model
            var response = _mapper.Map<EmpleadosUiResponse>(empleado);
            response.Persona = _mapper.Map<PersonaResponse>(persona);
            response.Sucursal = sucursal.Nombre;

            return response;
        }

        public async Task<EmpleadosUiResponse> UpdateUiEmpleado(EmpleadoUpdateUiRequest request)
        {
            // Buscar el empleado por su ID
            var empleadoExistente =  _empleadoRepository.BuscarporId(request.IdEmpleado);
            if (empleadoExistente == null)
            {
                throw new ArgumentException("El empleado especificado no existe.");
            }

            // Validar y actualizar la persona asociada al empleado
            var personaExistente = await _personaRepository.BuscarporId(empleadoExistente.IdPersona);
            if (personaExistente == null)
            {
                throw new ArgumentException("No se encontró la persona asociada al empleado.");
            }

            // Verificar si el correo electrónico ya está registrado por otra persona
            var empleadoConEmail =  _personaRepository.BuscarCorreo(request.Correo);
            if (empleadoConEmail != null && empleadoConEmail.IdPersona != personaExistente.IdPersona)
            {
                throw new ArgumentException("El correo electrónico ya se encuentra registrado.");
            }

            // Verificar si el número de teléfono ya está registrado por otra persona
            var empleadoConTelefono =  _personaRepository.BuscarTelefono(request.Telefono);
            if (empleadoConTelefono != null && empleadoConTelefono.IdPersona != personaExistente.IdPersona)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }

            // Actualizar los nombres y apellidos si han cambiado
            var nombres = request.Nombres.Split(' ', 2);
            var apellidos = request.Apellidos.Split(' ', 2);

            personaExistente.PrimerNombre = nombres[0];
            personaExistente.SegundoNombre = nombres.Length > 1 ? nombres[1] : null;
            personaExistente.ApellidoPaterno = apellidos[0];
            personaExistente.ApellidoMaterno = apellidos.Length > 1 ? apellidos[1] : null;
            personaExistente.Email = request.Correo.ToLower();
            personaExistente.Telefono = request.Telefono;
            personaExistente.NroDocumento = request.Identificacion;

            await _personaRepository.Update(personaExistente);

            // Obtener la sucursal por nombre
            var sucursal = await _sucursalRepository.GetBySucursalName(request.Sucursal);
            if (sucursal == null)
            {
                throw new ArgumentException("La sucursal especificada no existe.");
            }

            // Actualizar el rol del empleado y la sucursal
            var rol = await _rolesRepository.GetByRol(request.Rol);
            if (rol == null)
            {
                throw new ArgumentException("El rol especificado no existe.");
            }

            empleadoExistente.IdRol = rol.IdRol;
            empleadoExistente.IdSucursal = sucursal.IdSucursal;

            await _empleadoRepository.Update(empleadoExistente);

            // Mapear y devolver la respuesta
            var response = _mapper.Map<EmpleadosUiResponse>(empleadoExistente);
            response.Persona = _mapper.Map<PersonaResponse>(personaExistente);
            response.Sucursal = sucursal.Nombre;

            return response;
        }

        public async Task<bool> DeleteUiEmpleado(int idEmpleado)
        {
            var empleado = await _empleadoRepository.GetById(idEmpleado);
            if (empleado == null)
            {
                throw new ArgumentException(nameof(idEmpleado), "Empleado no encontrado");
            }

            var persona = await _personaRepository.BuscarporId(empleado.IdPersona);
            if (persona == null)
            {
                throw new ArgumentException("La persona asociada no existe.");
            }

            // Eliminar la persona asociada al empleado
            await _empleadoRepository.Delete(idEmpleado);

            // Eliminar la persona
            await _personaRepository.DeletePersona(persona.IdPersona);

            return true;
        }

        #endregion
    }
}
