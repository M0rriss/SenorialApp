using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Almacen.Proveedores
{
    public interface IProveedorRepository : ICrudRepository<Proveedor>
    {
        Task<List<ProveedorUiRequest>> UiProveedor();
        Task<Proveedor> InsertUiProveedor(Proveedor proveedor);
        Task<Proveedor> UpdateUiProveedor(Proveedor proveedor);
        Task<bool> DeleteUiProveedor(int IdProvedor);
        Task<Proveedor> BuscarporId(int id);
    }
}
