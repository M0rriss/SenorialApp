using DBSenorialModels.Senorial;
using IRepository.Schema_Produccion.Salidas;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Produccion.Salidas
{
    public class SalidaRepository : CrudRepository<Salida>, ISalidaRepository
    {
        public Task<GenericFilterResponse<Salida>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistrarSalidaAsync(Salida salida)
        {
            DetalleInventario? query = await (from detalle in db.DetalleInventarios
                                              where detalle.IdInsumo == salida.IdInsumo
                                              select detalle).FirstOrDefaultAsync();
            if (query == null)
            {
                throw new Exception("No se enctontro suministro");
            }
            query.StockTotal -= salida.Cantidad;
            await Create(salida);
            db.DetalleInventarios.Update(query);

            return true;
        }
    }
}
