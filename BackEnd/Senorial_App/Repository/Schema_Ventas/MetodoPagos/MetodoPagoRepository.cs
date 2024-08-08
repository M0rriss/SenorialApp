using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.MetodoPagos;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.MetodoPagos
{
    public class MetodoPagoRepository : CrudRepository<MetodoPago>, IMetodoPagoRepository
    {
        public Task<GenericFilterResponse<MetodoPago>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<List<MetodoPagoUiResponse>> UiMetodoPago()
        {
            return await db.MetodoPagos
                .Select(mp => new MetodoPagoUiResponse
                {
                    IdMetodo = mp.IdMetodo,
                    Descripcion = mp.Descripcion,
                    Estado = mp.Estado
                })
                .ToListAsync();
        }
        public async Task<MetodoPago> BuscarNombre(string nombre)
        {
            return await db.MetodoPagos
                .Where(mp => mp.Descripcion.ToLower() == nombre.ToLower())
                .FirstOrDefaultAsync();
        }
    }
}
