using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.ProductoSucursal;
using RequestResponseModels.Response.Schema_Ventas.ProductoSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.ProductoSucursal
{
    public interface IProductoSucursalBusiness : ICrudBusiness<ProductoSucursalRequest, ProductoSucursalResponse>
    {
    }
}
