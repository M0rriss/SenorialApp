using CommonModels.Common;
using DBSenorialModels.Estados;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Ventas.TbPedidoLlevar;
using IRepository.Schema_Ventas.Pedidos;
using IRepository.Schema_Ventas.PedioLlevar;
using Repository.Schema_Ventas.TbPedidoLlevar;
using RequestResponseModels.Request.Schema_Ventas.TbPedidoLlevar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.TbPedidoLlevar
{
    public class PedidoLlevarBusiness : IPedidoLlevarBusiness
    {
        private readonly IPedidoLlevarRepository _petoLlevarRepository;

        public PedidoLlevarBusiness()
        {
            _petoLlevarRepository = new PedidoLlevarRepository();
        }

        public async Task<CustomResponse> RegistarPedidoLlevar(PedidoLlevarRequest req)
        {
            PedidoLlevar pedido = new() 
            {
                IdEmpleado = req.IdEmpleado, 
                IdCliente = req.IdCliente, 
                FechaPedido = DateTime.Now,
                Estado = EstadoOrden.Pendiente.IdEstadoOrden,
                Total = 0,
                IdTipoPedido = req.IdTipoPedido 
            };
            await _petoLlevarRepository.Create(pedido);

            CustomResponse res = new()
            {
                Code= "200",
                Message = "Se registro Correctamente",
            };
            return res;

        }
    }
}
