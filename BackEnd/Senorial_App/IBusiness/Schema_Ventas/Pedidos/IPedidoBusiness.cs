using DBSenorialModels.View.Pedidos;
using RequestResponseModels.Request.Schema_Ventas.Pedidos;
using RequestResponseModels.Response.Schema_Ventas.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Pedidos
{
    public interface IPedidoBusiness
    {
        Task<PedidoResponse> GetPedidoById(int id);
        Task<List<PedidoResponse>> GetAllPedidos();
        Task<PedidoResponse> CreatePedido(PedidoRequest request);
        Task<PedidoResponse> UpdatePedido(PedidoRequest request);
        Task<bool> DeletePedido(int id);
        Task<List<VwPedido>> ObtenerPedidos();
        Task<List<VwDetPedido>> DetallePedido(int idPedido);
    }
}
