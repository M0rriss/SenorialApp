using DBSenorialModels.Senorial;
using IRepository.Schema_Almacen.Proveedores;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Proveedor> BuscarporId(int id)
        {
            var proveedor = dbset.Where(x => x.IdProveedor == id).FirstOrDefault();
            return proveedor;
        }


        public Task<GenericFilterResponse<Proveedor>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }


        public async Task<List<ProveedorUiRequest>> UiProveedor()
        {
            return await db.Personas.Join(
                    db.Proveedors,
                    p => p.IdPersona,
                    pro => pro.IdPersona,
                    (p, pro) => new ProveedorUiRequest
                    {
                        IdProveedor = pro.IdProveedor,
                        ProveedorNombreCompleto = $"{p.PrimerNombre} {p.ApellidoPaterno}",
                        Correo = p.Email,
                        Telefono = p.Telefono,
                        Dni = p.NroDocumento,
                        Distribuye = pro.Vende
                    }).ToListAsync();
        }

        public async Task<Proveedor> InsertUiProveedor(Proveedor proveedor)
        {
            await dbset.AddAsync(proveedor);
            await db.SaveChangesAsync();
            return proveedor;
        }
        public async Task<Proveedor> UpdateUiProveedor(Proveedor proveedor)
        {
            dbset.Update(proveedor);
            await db.SaveChangesAsync();
            return proveedor;
        }
        public async Task<bool> DeleteUiProveedor(int IdProvedor)
        {
            var proveedor = await db.Proveedors.FindAsync(IdProvedor);
            if (proveedor == null)
            {
                throw new ArgumentNullException(nameof(proveedor), "proveedor not found");
            }
            db.Remove(proveedor);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
