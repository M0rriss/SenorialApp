using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Clientes
{
    public interface IClienteRepository : ICrudRepository<Cliente>
    {
        public List<ClienteFullRequest> GetFull();
        public List<ClienteUiRequest> UiCliente();
    }
}
