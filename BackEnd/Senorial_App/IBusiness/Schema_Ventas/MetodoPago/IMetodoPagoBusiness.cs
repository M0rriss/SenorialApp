using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.MetodoPago;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.MetodoPago
{
    public interface IMetodoPagoBusiness : ICrudBusiness<MetodoPagoRequest, MetodoPagoResponse>
    {
    }
}
