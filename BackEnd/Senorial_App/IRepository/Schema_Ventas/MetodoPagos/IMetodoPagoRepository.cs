using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.MetodoPagos
{
    public interface IMetodoPagoRepository : ICrudRepository<MetodoPago>
    {
        Task<List<MetodoPagoUiResponse>> UiMetodoPago();
        Task<MetodoPago> BuscarNombre(string nombre);
    }
}
