using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Produccion.DetalleProduccion;
using RequestResponseModels.Response.Schema_Produccion.DetalleProduccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Produccion.DetalleProducciones
{
    public interface IDetalleProduccionBusiness : ICrudBusiness<DetalleProduccionRequest, DetalleProduccionResponse>
    {
    }
}
