using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.DetalleCompra;
using RequestResponseModels.Response.Schema_Almacen.DetalleCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.DetalleCompras
{
    public interface IDetalleCompraBusiness : ICrudBusiness<DetalleCompraRequest,DetalleCompraResponse>
    {
    }
}
