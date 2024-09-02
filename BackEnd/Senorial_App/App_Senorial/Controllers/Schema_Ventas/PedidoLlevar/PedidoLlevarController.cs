using Business.Schema_Ventas.TbPedidoLlevar;
using CommonModels.Common;
using IBusiness.Schema_Ventas.TbPedidoLlevar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.TbPedidoLlevar;

namespace App_Senorial.Controllers.Schema_Ventas.PedidoLlevar
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoLlevarController : ControllerBase
    {
        private readonly IPedidoLlevarBusiness _pedidoLlevarBusiness;
        /// <summary>
        /// 
        /// </summary>
        public PedidoLlevarController()
        {
            _pedidoLlevarBusiness = new PedidoLlevarBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<CustomResponse>> CrearPedidoLlevar([FromBody] PedidoLlevarRequest req)
        {
            CustomResponse res = await _pedidoLlevarBusiness.RegistarPedidoLlevar(req);
            return StatusCode(201, res);
        }
    }
}
