using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Almacen.Proveedores
{
    public interface IProveedorBusiness : ICrudBusiness<ProveedorRequest, ProveedorResponse>
    {
        Task<List<ProveedorUiRequest>> UiGetProveedor();
        Task<ProveedorUiResponse> InsertUiProveedor(ProveedorUiRequest request);
        Task<ProveedorUiResponse> UpdateUiProveedor(ProveedorUpdateUiRequest request);
        Task<bool> DeleteUiProveedor(int idProveedor);

    }
}
