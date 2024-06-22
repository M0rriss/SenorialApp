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
        public List<ProveedorUiRequest> UiProveedor();
        public List<ProveedorUiRequest> UiProveedorActualizar(ProveedorUiRequest request);

    }
}
