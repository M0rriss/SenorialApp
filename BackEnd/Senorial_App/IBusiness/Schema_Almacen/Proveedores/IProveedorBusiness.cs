using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Proveedores
{
    public interface IProveedorBusiness : ICrudBusiness<ProveedorRequest, ProveedorResponse>
    {
    }
}
