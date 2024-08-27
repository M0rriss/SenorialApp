using Business.Schema_Produccion.Salidas;
using CommonModels.Common;
using IBusiness.Schema_Produccion.Salidas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Produccion.Salidas;

namespace App_Senorial.Controllers.Schema_Produccion.Salidas
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalidaController : ControllerBase
    {
        private readonly ISalidaBusiness _salidaBusiness;
        /// <summary>
        /// 
        /// </summary>
        public SalidaController()
        {
            _salidaBusiness = new SalidaBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(template: "Registrar")]
        public async Task<ActionResult<CustomResponse>> RegistraSalida([FromBody] SalidaRequest req)
        {
            CustomResponse res = await _salidaBusiness.RegistarSalidaAsync(req);
            return StatusCode(201, res);
        }
    }
}
