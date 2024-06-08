using DBSenorialModels.Senorial;
using Repository.Schema_Generico.CRUD;
using IRepository.Schema_Ventas.DetalleVentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Generico.Filtro;

namespace Repository.Schema_Ventas.DetalleVentas
{
    public class DetalleVentaRepository : CrudRepository<DetalleVenta>, IDetalleVentaRepository
    {
        public Task<GenericFilterResponse<DetalleVenta>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
