using CommonModels.Common;
using RequestResponseModels.Request.Schema_Ventas.TbPedidoLlevar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.TbPedidoLlevar
{
    public interface IPedidoLlevarBusiness
    {
        Task<CustomResponse> RegistarPedidoLlevar(PedidoLlevarRequest req);
    }
}
