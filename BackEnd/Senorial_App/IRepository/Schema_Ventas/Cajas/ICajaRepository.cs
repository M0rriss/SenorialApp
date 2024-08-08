using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Cajas
{
    public interface ICajaRepository : ICrudRepository<Caja>
    {
        Task<AperturaCaja> AperturarCaja(AperturaCaja aperturaCaja);
        Task<List<AperturaCaja>> ObtenerHistorialAperturas(HistorialAperturaRequest request);
    }
}
