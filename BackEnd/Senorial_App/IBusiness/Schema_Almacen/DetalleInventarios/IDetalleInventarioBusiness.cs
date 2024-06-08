using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventario;
using RequestResponseModels.Response.Schema_Almacen.DetalleCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.DetalleInventarios
{
    public interface IDetalleInventarioBusiness : ICrudBusiness<DetalleInventarioRequest, DetalleCompraResponse>
    {
    }
}
