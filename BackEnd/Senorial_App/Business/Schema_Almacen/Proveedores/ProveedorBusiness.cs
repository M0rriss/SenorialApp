using AutoMapper;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Vml.Office;
using IBusiness.Schema_Almacen.Proveedores;
using IRepository.Schema_Almacen.Proveedores;
using IRepository.Schema_Usuarios.Personas;
using Repository.Schema_Almacen.Proveedores;
using Repository.Schema_Usuarios.Personas;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
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
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        public ProveedorBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _proveedorRepository = new ProveedorRepository();
            _personaRepository = new PersonaRepository();
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
            return response; 
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
        #region Insert,Update,Delete Usuarios
        public async Task<List<ProveedorUiRequest>> UiGetProveedor()
        {
            return await _proveedorRepository.UiProveedor();
        }

        public async Task<ProveedorUiResponse> InsertUiProveedor(ProveedorUiRequest request)
        {
            var existingEmail = _personaRepository.BuscarCorreo(request.Correo);
            if (existingEmail != null)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }
            var existingPhone = _personaRepository.BuscarTelefono(request.Telefono);
            if (existingPhone != null)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }
            var nombreCompleto = request.ProveedorNombre.Split(' ');
            var primerNombre = nombreCompleto[0];
            var apellidoPaterno = nombreCompleto.Length > 1 ? nombreCompleto[1] : "";
            var persona = new Persona
            {
                PrimerNombre = request.ProveedorNombre.Split(' ')[0], // Primer nombre
                ApellidoPaterno = request.ProveedorNombre.Split(' ')[1], // Apellido paterno
                Email = request.Correo.ToLower(),
                Telefono = request.Telefono,
                NroDocumento = request.Dni,
                Genero = "",
                IdTipoDocumento = 1
            };
            var personaCreada = await _personaRepository.Create(persona);
            var nuevoProveedor = new Proveedor
            {
                IdPersona = personaCreada.IdPersona,
                Vende = request.Distribuye  
            };
            var proveedorCreado = await _proveedorRepository.Create(nuevoProveedor);
            var response = _mapper.Map<ProveedorUiResponse>(proveedorCreado);
            response.Persona = _mapper.Map<PersonaResponse>(persona);
            return response;
        }

        public async Task<ProveedorUiResponse> UpdateUiProveedor(ProveedorUpdateUiRequest request)
        {
            var existingProveedor = _proveedorRepository.BuscarporId(request.IdProveedor);
            if(existingProveedor == null)
            {
                throw new ArgumentException(nameof(existingProveedor), "Proveedor not found");
            }
            var existingPersona = await _personaRepository.BuscarporId(existingProveedor.IdPersona);
            if(existingPersona == null)
            {
                throw new ArgumentException(nameof(existingProveedor), "Persona not found");
            }
            var proveedorEmail = _personaRepository.BuscarCorreo(request.Correo);
            if(proveedorEmail != null && proveedorEmail.IdPersona != existingProveedor.IdPersona)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }
            var userWithPhone = _personaRepository.BuscarTelefono(request.Telefono);
            if (userWithPhone != null && userWithPhone.IdPersona != existingProveedor.IdPersona)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }
            existingPersona.PrimerNombre = request.ProveedorNombre.Split(' ')[0];
            existingPersona.ApellidoPaterno = request.ProveedorNombre.Split(' ')[1];
            existingPersona.Email = request.Correo.ToLower();
            existingPersona.Telefono = request.Telefono;
            existingPersona.NroDocumento = request.Dni;
            var response = _mapper.Map<ProveedorUiResponse>(existingPersona);
            response.Distribuye = existingProveedor.Vende;
            response.Persona = _mapper.Map<PersonaResponse>(existingPersona);
            return response;

        }

        public async Task<bool> DeleteUiProveedor(int idProveedor)
        {
            var proveedor = await _personaRepository.GetById(idProveedor);
            if (proveedor == null)
            {
                throw new ArgumentNullException(nameof(proveedor), "Proveedor not found");
            }
            var persona = await _personaRepository.GetById(proveedor.IdPersona);
            if (persona == null)
            {
                throw new ArgumentException("La persona asociada no existe.");
            }
            // Eliminar la persona asociada al proveedor
            await _proveedorRepository.Delete(idProveedor);

            // Eliminar el proveedor
            await _personaRepository.DeletePersona(persona.IdPersona);

            return true;
        }
        #endregion
    }
}
