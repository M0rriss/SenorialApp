using AutoMapper;
using CommonModels.Common;
using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.PedidosLlevar;
using DocumentFormat.OpenXml.Office2010.Excel;
using IBusiness.Schema_Ventas.TbPedidoLlevar;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Ventas.Clientes;
using IRepository.Schema_Ventas.Pedidos;
using IRepository.Schema_Ventas.PedioLlevar;
using IRepository.Schema_Ventas.Productos;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Ventas.Clientes;
using Repository.Schema_Ventas.Productos;
using Repository.Schema_Ventas.TbPedidoLlevar;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Request.Schema_Ventas.TbDetallePedidoLlevar;
using RequestResponseModels.Request.Schema_Ventas.TbPedidoLlevar;
using RequestResponseModels.Response.Schema_Ventas.DetallePedidos;
using RequestResponseModels.Response.Schema_Ventas.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.TbPedidoLlevar
{
    public class PedidoLlevarBusiness : IPedidoLlevarBusiness
    {
        private readonly IPedidoLlevarRepository _pedidoLlevarRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProductoRepository _productoRepository;

        public PedidoLlevarBusiness(IMapper mapper)
        {
            _pedidoLlevarRepository = new PedidoLlevarRepository();
            _personaRepository = new PersonaRepository();
            _clienteRepository = new ClienteRepository();
            _productoRepository = new ProductoRepository();
            _mapper = mapper;
        }

        public async Task<OrdenLlevarResponse> CrearOrdenLlevar(OrdenLlevarRequest request)
        {
            // Verificar si la persona ya existe por el IdPersona (IdCliente en este caso)
            var persona = await _personaRepository.BuscarporId(request.IdCliente);

            if (persona == null)
            {
                string[] nombresSeparados = request.NombreCliente.Split(' ');
                string primerNombre = CapitalizarCondicionalmente(nombresSeparados[0]); // Capitalización condicional
                string segundoNombre = nombresSeparados.Length > 1 ? CapitalizarCondicionalmente(nombresSeparados[1]) : null;
                string apellidoPaterno = nombresSeparados.Length > 2 ? CapitalizarCondicionalmente(nombresSeparados[2]) : null;
                string apellidoMaterno = nombresSeparados.Length > 3 ? CapitalizarCondicionalmente(nombresSeparados[3]) : null;

                // Crear nueva persona
                persona = new Persona
                {
                    PrimerNombre = primerNombre,
                    SegundoNombre = segundoNombre,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    IdTipoDocumento = 1
                };

                await _personaRepository.Create(persona);
            }

            // Verificar si el cliente existe para esa persona
            var clienteExistente = await _clienteRepository.ObtenerCLientePorId(persona.IdPersona);

            if (clienteExistente == null)
            {
                var nuevoCliente = new Cliente
                {
                    IdPersona = persona.IdPersona
                };

                request.NombreCliente = $"{persona.PrimerNombre} {persona.SegundoNombre ?? ""} {persona.ApellidoPaterno} {persona.ApellidoMaterno}";

                await _clienteRepository.Create(nuevoCliente);
                request.IdCliente = nuevoCliente.IdCliente;
            }
            else
            {
                request.IdCliente = clienteExistente.IdCliente;
            }
            var pedidos = _mapper.Map<PedidoLlevar>(request);
            pedidos.Estado = EstadoOrden.Pendiente.IdEstadoOrden;
            pedidos.IdCliente = request.IdCliente;
            pedidos = await _pedidoLlevarRepository.CreatePedidoLlevar(pedidos);

            var response = _mapper.Map<OrdenLlevarResponse>(pedidos);
            response.NombreCliente = $"{persona.PrimerNombre} {persona.SegundoNombre ?? ""} {persona.ApellidoPaterno} {persona.ApellidoMaterno}".Trim();
            

            return response;
        }
        private string CapitalizarCondicionalmente(string input)
        {
            if (IsAllUpper(input) || IsAllLower(input))
            {
                // Si el input está todo en mayúsculas o todo en minúsculas, lo capitalizamos
                return string.Join(" ", input.Split(' ')
                    .Where(w => !string.IsNullOrEmpty(w))
                    .Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
            }

            // Si ya está capitalizado correctamente o es mixto, lo devolvemos tal cual
            return input;
        }
        private bool IsAllUpper(string input)
        {
            return input.All(char.IsUpper);
        }

        private bool IsAllLower(string input)
        {
            return input.All(char.IsLower);
        }
        //public async Task<CustomResponse> RegistarPedidoLlevar(PedidoLlevarRequest req)
        //{
        //    PedidoLlevar pedido = new() 
        //    {
        //        IdEmpleado = req.IdEmpleado, 
        //        IdCliente = req.IdCliente, 
        //        FechaPedido = DateTime.Now,
        //        Estado = EstadoOrden.Pendiente.IdEstadoOrden,
        //        Total = 0,
        //        IdTipoPedido = req.IdTipoPedido 
        //    };
        //    await _pedidoLlevarRepository.Create(pedido);

        //    CustomResponse res = new()
        //    {
        //        Code= "200",
        //        Message = "Se registro Correctamente",
        //    };
        //    return res;

        //}
       

        public async Task<List<VwPedidoLlevar>> ObtenerPedidosLlevar()
        {
            return await _pedidoLlevarRepository.ObtenerPedidosLlevarAsync();
        }

        // Método para obtener el detalle de un pedido para llevar por ID
        public async Task<List<VwDetPedidoLlevar>> DetallePedidoLlevar(int idPedidoLlevar)
        {
            return await _pedidoLlevarRepository.DetallePedidoLlevarAsync(idPedidoLlevar);
        }

        // Método para marcar un pedido para llevar como listo
        public async Task<CustomResponse> PedidoLlevarListo(int idPedidoLlevar)
        {
            CustomResponse res = new()
            {
                Code = "200",
                Message = "Pedido para llevar listo"
            };
            await _pedidoLlevarRepository.PedidoListoAsync(idPedidoLlevar);
            return res;
        }

        // Método para cancelar un pedido para llevar
        public async Task<CustomResponse> CancelarPedidoLlevar(int idPedidoLlevar)
        {
            CustomResponse res = new()
            {
                Code = "200",
                Message = "Se canceló el pedido para llevar"
            };
            await _pedidoLlevarRepository.CancelarPedidoAsync(idPedidoLlevar);
            return res;
        }
    }
}
