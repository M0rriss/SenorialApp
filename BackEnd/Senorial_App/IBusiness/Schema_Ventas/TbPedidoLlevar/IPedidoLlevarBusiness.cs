using CommonModels.Common;
using DBSenorialModels.View.PedidosLlevar;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Request.Schema_Ventas.TbPedidoLlevar;
using RequestResponseModels.Response.Schema_Ventas.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.TbPedidoLlevar
{
    public interface IPedidoLlevarBusiness
    {
        //Task<CustomResponse> RegistarPedidoLlevar(PedidoLlevarRequest req);
        Task<List<VwPedidoLlevar>> ObtenerPedidosLlevar();
        Task<List<VwDetPedidoLlevar>> DetallePedidoLlevar(int idPedidoLlevar);
        Task<CustomResponse> PedidoLlevarListo(int idPedidoLlevar);
        Task<CustomResponse> CancelarPedidoLlevar(int idPedidoLlevar);
        Task<OrdenLlevarResponse> CrearOrdenLlevar(OrdenLlevarRequest request);


    }
}
