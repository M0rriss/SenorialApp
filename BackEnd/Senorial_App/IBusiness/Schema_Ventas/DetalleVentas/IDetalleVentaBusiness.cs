using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.DetalleVentas;
using RequestResponseModels.Response.Schema_Ventas.DetalleVentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.DetalleVentas
{
    public interface IDetalleVentaBusiness : ICrudBusiness<DetalleVentaRequest, DetalleVentaResponse>
    {
    }
}
