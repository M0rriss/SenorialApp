using Business.Schema_Ventas.TbDetallePedidoLlevar;
using CommonModels.Common;
using IBusiness.Schema_Ventas.TbDetallePedidoLlevar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.TbDetallePedidoLlevar;

namespace App_Senorial.Controllers.Schema_Ventas.DetallePedidoLlevar
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoLlevarController : ControllerBase
    {

        private readonly IDetallePedidoLlevarBusiness _detallePedidoLlevarBusiness;

        /// <summary>
        /// 
        /// </summary>
        public DetallePedidoLlevarController()
        {
            _detallePedidoLlevarBusiness = new TbDetallePedidoLlevarBusiness();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<CustomResponse>> CrearDetalleOrden([FromBody] List<DetallePedidoLlevarRequest> req)
        {
            CustomResponse res = await _detallePedidoLlevarBusiness.RegistarDetallePedido(req);
            return StatusCode(201,res);
        }
    }
}
