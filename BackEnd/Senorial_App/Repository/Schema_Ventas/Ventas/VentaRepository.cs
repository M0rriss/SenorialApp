using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Ventas;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Ventas
{
    public class VentaRepository : CrudRepository<Venta>, IVentaRepository
    {
        public Task<GenericFilterResponse<Venta>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<Venta> GetVentaById(int id)
        {
            return await db.Ventas
                .Include(v => v.DetalleVenta)
                .ThenInclude(dv => dv.Producto)
                .FirstOrDefaultAsync(v => v.IdVenta == id);
        }

        public async Task<List<Venta>> GetAllVentas()
        {
            return await db.Ventas
                .Include(v => v.DetalleVenta)
                .ThenInclude(dv => dv.Producto)
                .ToListAsync();
        }

        public async Task<Venta> CreateVenta(Venta venta)
        {
            db.Ventas.Add(venta);
            await db.SaveChangesAsync();
            return venta;
        }

        public async Task<Venta> UpdateVenta(Venta venta)
        {
            db.Ventas.Update(venta);
            await db.SaveChangesAsync();
            return venta;
        }

        public async Task<bool> DeleteVenta(int id)
        {
            var venta = await db.Ventas.FindAsync(id);
            if (venta != null)
            {
                db.Ventas.Remove(venta);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
