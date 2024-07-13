using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.ConteoDIneros
{
    public interface IConteoDineroRepository : ICrudRepository<ConteoDinero>
    {
        Task RegistrarConteoDinero(ConteoDinero conteo);
        Task<List<ConteoDinero>> ObtenerConteoPorApertura(int idApertura);
    }
}
