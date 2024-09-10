using DBSenorialModels.Senorial;
using DBSenorialModels.View.PedidosLlevar;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.PedioLlevar
{
    public interface IPedidoLlevarRepository : ICrudRepository<PedidoLlevar>
    {
        Task<List<VwPedidoLlevar>> ObtenerPedidosLlevarAsync();
        Task<List<VwDetPedidoLlevar>> DetallePedidoLlevarAsync(int idPedidoLlevar);
        Task<bool> PedidoListoAsync(int idPedidoLlevar);
        Task<bool> CancelarPedidoAsync(int idPedidoLlevar);
        // Obtener un pedido para llevar por ID
        Task<PedidoLlevar> GetPedidoLlevarById(int id);

        // Obtener todos los pedidos para llevar
        Task<List<PedidoLlevar>> GetAllPedidosLlevar();

        // Crear un nuevo pedido para llevar
        Task<PedidoLlevar> CreatePedidoLlevar(PedidoLlevar pedidoLlevar);

        // Actualizar un pedido para llevar existente
        Task<PedidoLlevar> UpdatePedidoLlevar(PedidoLlevar pedidoLlevar);

        // Eliminar un pedido para llevar por ID
        Task<bool> DeletePedidoLlevar(int id);

    }
}
