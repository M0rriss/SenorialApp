using AutoMapper;
using CommonModels.Common;
using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Pedidos;
using IBusiness.Schema_Ventas.Pedidos;
using IRepository.Schema_Ventas.Mesas;
using IRepository.Schema_Ventas.Pedidos;
using Microsoft.AspNetCore.Identity;
using PusherServer;
using Repository.Schema_Ventas.Mesas;
using Repository.Schema_Ventas.Pedidos;
using RequestResponseModels.Request.Schema_Ventas.DetallePedidos;
using RequestResponseModels.Request.Schema_Ventas.Pedidos;
using RequestResponseModels.Response.Schema_Ventas.DetallePedidos;
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
        private readonly IMesaRepository _mesaRepository;
        public PedidoBusiness( IMapper mapper)
        {
            _pedidoRepository = new PedidoRepository();
            _mesaRepository = new MesaRepository();
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
       
            var pedido = _mapper.Map<Pedido>(request);
            pedido.Estado = EstadoOrden.Pendiente.IdEstadoOrden;
            pedido.IdMesa = request.IdMesa;
            var mesa = await _mesaRepository.GetMesaByIdAsync(pedido.IdMesa); // Obtener la mesa por ID
            if (mesa != null)
            {
                mesa.EstadoMesaLocal = EstadoLocal.Ocupado.IdEstadoMesa; // Cambiar el estado de la mesa a "Ocupado"
                await _mesaRepository.UpdateMesaAsync(mesa); // Guardar los cambios en la base de datos
            }
            //pedido.IdPedido = request.IdPedido;
            //pedido.IdTipoPedido = request.IdTipoPedido;
            pedido = await _pedidoRepository.CreatePedido(pedido);
            var response = _mapper.Map<PedidoResponse>(pedido);
            return response;
        }

        public async Task<PedidoResponse> UpdatePedido(PedidoRequest request)
        {
            //var pedido = _mapper.Map<Pedido>(request);
            //pedido = await _pedidoRepository.UpdatePedido(pedido);
            //var response = _mapper.Map<PedidoResponse>(pedido);
            //return response;
            // Verificar si el pedido existe
            // Obtener el pedido existente
            var existingPedido = await _pedidoRepository.GetPedidoById(request.IdPedido);

            if (existingPedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            // Actualizar el pedido
            existingPedido = _mapper.Map<Pedido>(request);
            existingPedido.Estado = EstadoOrden.Pendiente.IdEstadoOrden;
            existingPedido.IdMesa = request.IdMesa;

           
            existingPedido = await _pedidoRepository.UpdatePedido(existingPedido);

            // Actualizar los detalles del pedido
            await UpdateDetalles(existingPedido, request.Detalles);

            // Mapear el pedido actualizado a PedidoResponse
            var response = _mapper.Map<PedidoResponse>(existingPedido);
            return response;

        }
        private async Task UpdateDetalles(Pedido existingPedido, List<DetallePedidoRequest> detalleRequests)
        {
            var existingDetalles = await _pedidoRepository.GetDetallesByPedidoId(existingPedido.IdPedido);
            var updatedDetalles = detalleRequests.Select(d => new DetallePedido
            {
                IdProducto = d.IdProducto,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario
            }).ToList();

            // Actualiza los detalles existentes
            foreach (var updatedDetalle in updatedDetalles)
            {
                var existingDetalle = existingDetalles.FirstOrDefault(d => d.IdDetallePedido == updatedDetalle.IdDetallePedido);

                if (existingDetalle != null)
                {
                    _mapper.Map(updatedDetalle, existingDetalle);
                    await _pedidoRepository.UpdateDetalle(existingDetalle);
                }
                else
                {
                    var newDetalle = new DetallePedido
                    {
                        IdPedido = existingPedido.IdPedido,
                        IdProducto = updatedDetalle.IdProducto,
                        Cantidad = updatedDetalle.Cantidad,
                        PrecioUnitario = updatedDetalle.PrecioUnitario
                    };

                    await _pedidoRepository.AddDetalle(newDetalle);
                }
            }

            // Elimina los detalles que ya no están en la solicitud
            var detallesParaEliminar = existingDetalles
                .Where(d => !updatedDetalles.Any(ud => ud.IdDetallePedido == d.IdDetallePedido))
                .ToList();

            foreach (var detalle in detallesParaEliminar)
            {
                await _pedidoRepository.RemoveDetalle(detalle);
            }
        }


        public async Task<bool> DeletePedido(int id)
        {
            return await _pedidoRepository.DeletePedido(id);
        }
        #region PEDIDOS DASHBOARD
        public async Task<List<VwPedido>> ObtenerPedidos()
        {
            return await _pedidoRepository.ObtenerPedidosAsync();
        }

        public async Task<List<VwDetPedido>> DetallePedido(int idPedido)
        {
            return await _pedidoRepository.DetallePedidoAsync(idPedido);
        }

        public async Task<CustomResponse> PedidoListo(int idPedido)
        {
            CustomResponse res = new()
            {
                Code = "200",
                Message = "Pedido Listo"
            };
            await _pedidoRepository.PedidoListoAsync(idPedido);
            return res;
        }

        public async Task<CustomResponse> CancelarPedido(int idPedido)
        {
            CustomResponse res = new()
            {
                Code = "200",
                Message = "Se cancelo el pedido"
            };
            await _pedidoRepository.CancelarPedidoAsync(idPedido);
            //var pedido = new Pedido();
            
            
            return res;
        }
        #endregion PEDIDOS DASHBOARD
    }
}
