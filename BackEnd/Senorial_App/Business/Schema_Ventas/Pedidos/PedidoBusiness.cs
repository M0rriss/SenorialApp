using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.Pedidos;
using IRepository.Schema_Ventas.Pedidos;
using Microsoft.AspNetCore.Identity;
using PusherServer;
using Repository.Schema_Ventas.Pedidos;
using RequestResponseModels.Request.Schema_Ventas.Pedidos;
using RequestResponseModels.Response.Schema_Ventas.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Pedidos
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoBusiness( IMapper mapper)
        {
            _pedidoRepository = new PedidoRepository();
            _mapper = mapper;
        }
        public async Task<PedidoResponse> GetPedidoById(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoById(id);
            var response = _mapper.Map<PedidoResponse>(pedido);
            return response;
        }

        public async Task<List<PedidoResponse>> GetAllPedidos()
        {
            var pedidos = await _pedidoRepository.GetAllPedidos();
            var response = _mapper.Map<List<PedidoResponse>>(pedidos);
            return response;
        }

        public async Task<PedidoResponse> CreatePedido(PedidoRequest request)
        {
        //    var options = new PusherOptions
        //    {
        //        Cluster = "sa1",
        //        Encrypted = true
        //    };
        //    //JALAR DATA DE BD DE MESAS "PEDIDOS"
        //    var mesas = new List<object>
        //{
        //    new { idMesa = 1, estado = "Ocupado" },
        //    new { idMesa = 2, estado = "Disponible" },
        //    new { idMesa = 3, estado = "Facturado" }
        //};
        //    var pusher = new Pusher(
        //      "1851156",
        //      "ad70a1dc0ed70ee4e9ef",
        //      "884a08eddbb7cb221dda",
        //      options);

        //    var result = await pusher.TriggerAsync(
        //      "my-channel",
        //      "my-event",
        //      mesas);

            var pedido = _mapper.Map<Pedido>(request);
            pedido = await _pedidoRepository.CreatePedido(pedido);
            var response = _mapper.Map<PedidoResponse>(pedido);
            return response;
        }

        public async Task<PedidoResponse> UpdatePedido(PedidoRequest request)
        {
            var pedido = _mapper.Map<Pedido>(request);
            pedido = await _pedidoRepository.UpdatePedido(pedido);
            var response = _mapper.Map<PedidoResponse>(pedido);
            return response;
        }

        public async Task<bool> DeletePedido(int id)
        {
            return await _pedidoRepository.DeletePedido(id);
        }
    }
}
