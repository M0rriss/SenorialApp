using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Ventas.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Ventas.Cliente
{
    public interface IClienteBusiness : ICrudBusiness<ClienteRequest, ClienteResponse>
    {
        public List<ClienteFullRequest> GetFull();
    }
}
