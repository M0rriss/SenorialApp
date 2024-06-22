using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Proveedores;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Almacen.Proveedores
{
    public class ProveedorRepository : CrudRepository<Proveedor>, IProveedorRepository
    {
        public Task<GenericFilterResponse<Proveedor>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorUiRequest> UiProveedor()
        {
            return db.Personas.Join(
                    db.Proveedors,
                    p => p.IdPersona,
                    pro => pro.IdPersona,
                    (p, pro) => new ProveedorUiRequest
                    {
                        IdProveedor = p.IdPersona,
                        ProveedorNombre = $"{p.PrimerNombre} {p.SegundoNombre} {p.ApellidoPaterno} {p.ApellidoMaterno}",
                        Correo = p.Email,
                        Telefono = p.Telefono,
                        Dni = p.NroDocumento,
                        Distribuye = pro.Vende
                    }).ToList();
        }

        public List<ProveedorUiRequest> UiProveedorActualizar(ProveedorUiRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
