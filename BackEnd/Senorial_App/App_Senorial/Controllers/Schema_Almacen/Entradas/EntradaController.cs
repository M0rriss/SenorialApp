using Business.Schema_Almacen.Entradas;
using CommonModels.Common;
using IBusiness.Schema_Almacen.Entradas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Entradas;

namespace App_Senorial.Controllers.Schema_Almacen.Entradas
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaBusiness _entradaBusiness;
        /// <summary>
        /// 
        /// </summary>
        public EntradaController()
        {
            _entradaBusiness = new EntradaBusiness();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(template: "Registrar")]
        public async Task<ActionResult<CustomResponse>> RegistraEntrada([FromBody] EntradaRequest req)
        {
            CustomResponse res = await _entradaBusiness.RegistrarIngreso(req);
            return StatusCode(201, res);
        }
    }
}
