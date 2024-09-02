using Business.Servicios;
using IBusiness.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Response.ApisPeru;

namespace App_Senorial.Controllers.Servicios
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosBusiness _serviciosBusiness;
        /// <summary>
        /// 
        /// </summary>
        public ServiciosController()
        {
            _serviciosBusiness = new ServiciosBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Dni")]
        public async Task<ActionResult<DniResponse>> BuscarDni([FromQuery] string dni)
        {
            DniResponse res = await _serviciosBusiness.BuscarDni(dni);
            return Ok(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Ruc")]
        public async Task<ActionResult<RucResponse>> BuscarRuc([FromQuery] string ruc)
        {
            RucResponse res = await _serviciosBusiness.BuscarRuc(ruc);
            return Ok(res);
        }
    }
}
