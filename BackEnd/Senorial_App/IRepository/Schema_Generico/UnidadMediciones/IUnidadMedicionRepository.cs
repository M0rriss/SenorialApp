using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Generico.UnidadMediciones
{
    public interface IUnidadMedicionRepository : ICrudRepository<UnidadMedicion>
 
    {
        Task<UnidadMedicion> ObtenerUnidadMedidaPorNombre(string nombre);
        Task<UnidadMedicion> BuscarporId(int id);
    }
}
