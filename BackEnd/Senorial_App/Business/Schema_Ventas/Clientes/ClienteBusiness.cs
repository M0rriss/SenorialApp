using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Cliente;
using IRepository.Schema_Ventas.Clientes;
using Repository.Schema_Ventas.Clientes;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Generico.Filtro;
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
        private readonly IMapper _mapper;
        public ClienteBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = new ClienteRepository();
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
        public List<ClienteFullRequest> GetFull()
        {
            return _clienteRepository.GetFull();
        }

    }
}
