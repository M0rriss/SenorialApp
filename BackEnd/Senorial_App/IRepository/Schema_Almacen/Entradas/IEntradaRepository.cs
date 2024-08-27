using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Almacen.Entradas
{
    public interface IEntradaRepository : ICrudRepository<Entrada>
    {
        Task<bool> RegistrarIngresoAsync(Entrada entrada);
    }
}
