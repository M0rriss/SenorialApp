using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.TipoTransaccion;
using RequestResponseModels.Response.Schema_Ventas.TipoTransaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.TipoTransaccion
{
    public interface ITipoTransaccionBusiness : ICrudBusiness<TipoTransaccionRequest, TipoTransaccionResponse>
    {
    }
}
