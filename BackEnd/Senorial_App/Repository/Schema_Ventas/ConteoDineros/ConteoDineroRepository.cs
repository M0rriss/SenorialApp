using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.ConteoDIneros;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.ConteoDineros
{
    public class ConteoDineroRepository : CrudRepository<ConteoDinero>, IConteoDineroRepository
    {
        public Task<GenericFilterResponse<ConteoDinero>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task RegistrarConteoDinero(ConteoDinero conteo)
        {
            db.ConteoDinero.Add(conteo);
            await db.SaveChangesAsync();
        }

        public async Task<List<ConteoDinero>> ObtenerConteoPorApertura(int idApertura)
        {
            return await db.ConteoDinero.Where(c => c.IdApertura == idApertura).ToListAsync();
        }

    }
}
