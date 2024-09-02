using RequestResponseModels.Response.ApisPeru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Servicios
{
    public interface IServiciosBusiness
    {
        Task<DniResponse> BuscarDni(string dni);
        Task<RucResponse> BuscarRuc(string ruc);
    }
}
