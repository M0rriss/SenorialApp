using DBSenorialModels.Senorial;
using DBSenorialModels.View.Mesa;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Mesas
{
    public interface IMesaRepository : ICrudRepository<Mesa>
    {
        Task<List<VwMesa>> MesasLocal();
        Task<List<VwMesaDetalle>> ObtenerDetallesDeMesasAsync();
    }
}
