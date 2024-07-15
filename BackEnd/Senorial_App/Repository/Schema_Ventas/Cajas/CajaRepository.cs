using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Cajas;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Cajas
{
    public class CajaRepository : CrudRepository<Caja>, ICajaRepository
    {

        public async Task<GenericFilterResponse<Caja>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<AperturaCaja> AperturarCaja(AperturaCaja aperturaCaja)
        {
            db.AperturaCajas.Add(aperturaCaja);
            await db.SaveChangesAsync();
            return aperturaCaja;
        }

        public async Task<List<AperturaCaja>> ObtenerHistorialAperturas(HistorialAperturaRequest request)
        {
            var query = db.AperturaCajas.AsQueryable();

            if (request.FechaInicio.HasValue)
            {
                query = query.Where(a => a.HoraFechaInicio >= request.FechaInicio.Value);
            }

            if (request.FechaFin.HasValue)
            {
                query = query.Where(a => a.HoraFechaInicio <= request.FechaFin.Value);
            }

            if (request.IdCaja.HasValue)
            {
                query = query.Where(a => a.IdCaja == request.IdCaja.Value);
            }

            var response = await query.Include(a => a.Venta)
                             .ThenInclude(v => v.DetalleVenta)
                             .ThenInclude(dv => dv.IdProductoSucursal)
                             .ToListAsync();
            return response;
        }
    }
}
