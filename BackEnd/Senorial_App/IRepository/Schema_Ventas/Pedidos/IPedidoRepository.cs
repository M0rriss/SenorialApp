using DBSenorialModels.Senorial;
using DBSenorialModels.View.Pedidos;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Pedidos
{
    public interface IPedidoRepository: ICrudRepository<Pedido>
    {
        Task<Pedido> GetPedidoById(int id);
        Task<List<Pedido>> GetAllPedidos();
        Task<Pedido> CreatePedido(Pedido pedido);
        Task<Pedido> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(int id);
        Task<List<VwPedido>> ObtenerPedidosAsync();
        Task<List<VwDetPedido>> DetallePedidoAsync(int idPedido);
        Task<bool> PedidoListoAsync(int idPedido);
        Task<bool> CancelarPedidoAsync(int idPedido);
    }
}
