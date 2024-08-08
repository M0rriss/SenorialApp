using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.UnidadMediciones;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Generico.UnidadMediciones
{
    public class UnidadMedicionRepository : CrudRepository<UnidadMedicion>, IUnidadMedicionRepository
    {
        public Task<GenericFilterResponse<UnidadMedicion>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<UnidadMedicion> ObtenerUnidadMedidaPorNombre(string nombre)
        {
            return await db.UnidadMedicions.FirstOrDefaultAsync(u => u.Abreviacion == nombre);
        }

        public async Task<UnidadMedicion> BuscarporId(int id)
        {
            return await db.UnidadMedicions.FirstOrDefaultAsync(u => u.IdUnidad == id);
        }
    }
}
