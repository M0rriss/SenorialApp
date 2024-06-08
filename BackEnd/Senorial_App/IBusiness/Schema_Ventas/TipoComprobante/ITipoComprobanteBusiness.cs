using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.TipoComprobante;
using RequestResponseModels.Response.Schema_Ventas.TipoComprobante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.TipoComprobante
{
    public interface ITipoComprobanteBusiness : ICrudBusiness<TipoComprobanteRequest, TipoComprobanteResponse>
    {
    }
}
