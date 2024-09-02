using IBusiness.Servicios;
using IServices.PeruService;
using RequestResponseModels.Response.ApisPeru;
using Services.PeruService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Servicios
{
    public class ServiciosBusiness : IServiciosBusiness
    {
        private readonly IApisPeruService _apisPeruService;

        public ServiciosBusiness()
        {
            _apisPeruService = new ApisPeruService();
        }

        public async Task<DniResponse> BuscarDni(string dni)
        {
            return await _apisPeruService.BuscarDni(dni);
        }
        public async Task<RucResponse> BuscarRuc(string ruc)
        {
            return await _apisPeruService.BuscarRuc(ruc);
        }
    }
}
