using CommonModels.Common;
using RequestResponseModels.Request.Schema_Ventas.TbDetallePedidoLlevar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.TbDetallePedidoLlevar
{
    public interface IDetallePedidoLlevarBusiness
    {
        Task<CustomResponse> RegistarDetallePedido(List<DetallePedidoLlevarRequest> req);
    }
}
