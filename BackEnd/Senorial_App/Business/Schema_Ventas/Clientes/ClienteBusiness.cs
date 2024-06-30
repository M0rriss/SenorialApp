using AutoMapper;
using Azure;
using Azure.Core;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using IBusiness.Schema_Ventas.Cliente;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Roles;
using IRepository.Schema_Ventas.Clientes;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Roles;
using Repository.Schema_Ventas.Clientes;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Ventas.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Clientes
{
    public class ClienteBusiness : IClienteBusiness
    {
        #region Dependency Injecction
        private readonly IClienteRepository _clienteRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;
        public ClienteBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = new ClienteRepository();
            _personaRepository = new PersonaRepository();
            _rolesRepository = new RolesRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<ClienteResponse>> GetAll()
        {
            List<Cliente> cliente = await _clienteRepository.GetAll();
            var response = _mapper.Map<List<ClienteResponse>>(cliente);
            return response;
        }
        public async Task<ClienteResponse> GetById(int id)
        {
            Cliente cliente = await _clienteRepository.GetById(id);
            var response = _mapper.Map<ClienteResponse>(cliente);
            return response;
        }

        public async Task<ClienteResponse> Create(ClienteRequest entity)
        {
            Cliente cliente = _mapper.Map<Cliente>(entity);
            cliente = await _clienteRepository.Create(cliente);
            var response = _mapper.Map<ClienteResponse>(cliente);
            return response;
        }

        public async Task<List<ClienteResponse>> CreateMultiple(List<ClienteRequest> list)
        {
            var cliente = _mapper.Map<List<Cliente>>(list);
            cliente = await _clienteRepository.CreateMultiple(cliente);
            var response = _mapper.Map<List<ClienteResponse>>(cliente);
            return response;
        }

        public async Task<ClienteResponse> Update(ClienteRequest entity)
        {
            var cliente = _mapper.Map<Cliente>(entity);
            cliente = await _clienteRepository.Update(cliente);
            var response = _mapper.Map<ClienteResponse>(cliente);
            return response; ;
        }

        public async Task<List<ClienteResponse>> UpdateMultiple(List<ClienteRequest> list)
        {
            var cliente = _mapper.Map<List<Cliente>>(list);
            cliente = await _clienteRepository.UpdateMultiple(cliente);
            var response = _mapper.Map<List<ClienteResponse>>(cliente);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _clienteRepository.Delete(id);
            return result;
        }

        public async Task<List<ClienteRequest>> DeleteMultiple(List<ClienteRequest> list)
        {
            var cliente = _mapper.Map<List<Cliente>>(list);
            var deletedCount = await _clienteRepository.DeleteMultiple(cliente);
            return list;

        }

        public async Task<GenericFilterResponse<ClienteResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _clienteRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<ClienteResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        #endregion
        public async Task<List<ClienteUiRequest>> UiGetCliente()
        {
            return await _clienteRepository.UiCliente();
        }
        public async Task<ClienteUiResponse> InsertUiCliente(ClienteUiRequest request)
        {
            // Validar si el correo ya está registrado
            var existingEmail =  _personaRepository.BuscarCorreo(request.Correo);
            if (existingEmail != null)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }

            // Validar si el teléfono ya está registrado
            var existingPhone =  _personaRepository.BuscarTelefono(request.Telefono);
            if (existingPhone != null)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }

            // Crear una nueva persona
            var persona = new Persona
            {
                PrimerNombre = request.Nombres.Split(' ')[0], // Primer nombre
                ApellidoPaterno = request.Nombres.Split(' ')[1], // Apellido paterno
                Email = request.Correo.ToLower(),
                Telefono = request.Telefono,
                // Completar otros campos de Persona según sea necesario
            };

            // Guardar la persona en el repositorio
            var personaCreada = await _personaRepository.Create(persona);

            // Crear un nuevo cliente asociado a la persona
            var nuevoCliente = new Cliente
            {
                IdPersona = personaCreada.IdPersona,
                // Completar otros campos de Cliente según sea necesario
            };

            // Guardar el cliente en el repositorio
            var clienteCreado = await _clienteRepository.Create(nuevoCliente);

            // Mapear la persona creada a ClienteUiResponse para devolver como respuesta
            var clienteResponse = _mapper.Map<ClienteUiResponse>(personaCreada);
            clienteResponse.DNI = personaCreada.NroDocumento; // Asegúrate de incluir el número de documento si es necesario
            clienteResponse.Persona = _mapper.Map<PersonaResponse>(personaCreada);

            return clienteResponse;
        }

        public async Task<ClienteUiResponse> UpdateUiCliente(ClienteUpdateUiRequest request)
        {

            // Obtener el cliente asociado al IdCliente
            var existingCliente =  _clienteRepository.BuscarporId(request.IdCliente);
            if (existingCliente == null)
            {
                throw new ArgumentNullException(nameof(existingCliente), "Cliente not found");
            }

            // Obtener la persona asociada al cliente
            var existingPersona = await _personaRepository.BuscarporId(existingCliente.IdPersona);
            if (existingPersona == null)
            {
                throw new ArgumentNullException(nameof(existingPersona), "Persona not found");
            }

            // Validar si el nuevo correo está en uso por otro usuario
            var userWithEmail =  _personaRepository.BuscarCorreo(request.Correo);
            if (userWithEmail != null && userWithEmail.IdPersona != existingCliente.IdPersona)
            {
                throw new ArgumentException("El correo electrónico ya está registrado.");
            }

            // Validar si el nuevo teléfono está en uso por otro usuario
            var userWithPhone =  _personaRepository.BuscarTelefono(request.Telefono);
            if (userWithPhone != null && userWithPhone.IdPersona != existingCliente.IdPersona)
            {
                throw new ArgumentException("El número de teléfono ya está registrado.");
            }

            // Actualizar detalles de la persona
            existingPersona.PrimerNombre = request.Nombres.Split(' ')[0];
            existingPersona.ApellidoPaterno = request.Nombres.Split(' ')[1];
            existingPersona.Email = request.Correo.ToLower();
            existingPersona.Telefono = request.Telefono;
            // Actualizar otros campos de persona según sea necesario

            var response = _mapper.Map<ClienteUiResponse>(existingPersona);
            response.DNI = existingPersona.NroDocumento; // Asegúrate de incluir el número de documento si es necesario

            await _personaRepository.Update(existingPersona);
            // Mapear la persona actualizada a ClienteUiResponse para devolver como respuesta
            response.Persona = _mapper.Map<PersonaResponse>(existingPersona);

            return response;
        }

        public async Task<bool> DeleteUiCliente(int idCliente)
        {
            // Buscar la persona asociada al cliente
            var cliente = await _personaRepository.GetById(idCliente);
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "Persona not found");
            }
            var persona = await _personaRepository.GetById(cliente.IdPersona);
            if (persona == null)
            {
                throw new ArgumentException("La persona asociada no existe.");
            }
            // Eliminar la persona y sus referencias
            await _personaRepository.DeletePersona(idCliente);

            // Eliminar cualquier otra referencia o entidad relacionada si es necesario

            return true;
        }
    }

}
