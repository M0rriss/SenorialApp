using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.AperturaCajas;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.AperturaCajas
{
    public class AperturaCajaRepository : CrudRepository<AperturaCaja>, IAperturaCajaRepository
    {
        public Task<GenericFilterResponse<AperturaCaja>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AperturaCaja> ObtenerAperturaPorId(int id)
        {
           var response = await db.AperturaCajas
                              .Include(a => a.Conteos)
                             .Include(a => a.Venta)
                             .ThenInclude(v => v.DetalleVenta)
                             .ThenInclude(dv => dv.IdProductoSucursalNavigation)
                             .SingleOrDefaultAsync(a => a.IdApertura == id);
            return response;
        }

        public async Task<ConteoDinero> RegistrarConteoDinero(ConteoDinero conteo)
        {
            db.ConteoDinero.Add(conteo);
            await db.SaveChangesAsync();
            return conteo;
        }
    }
}
