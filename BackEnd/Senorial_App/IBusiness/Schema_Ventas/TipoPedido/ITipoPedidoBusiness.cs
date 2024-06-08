using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.TipoPedido;
using RequestResponseModels.Response.Schema_Ventas.TipoPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.TipoPedido
{
    public interface ITipoPedidoBusiness : ICrudBusiness<TipoPedidoRequest, TipoPedidoResponse>
    {
    }
}
