using DBSenorialModels.Senorial;
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
    }
}
