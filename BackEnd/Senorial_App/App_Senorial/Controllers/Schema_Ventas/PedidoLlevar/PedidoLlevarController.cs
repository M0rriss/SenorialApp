using AutoMapper;
using Business.Schema_Ventas.TbPedidoLlevar;
using CommonModels.Common;
using DBSenorialModels.View.PedidosLlevar;
using IBusiness.Schema_Ventas.TbPedidoLlevar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Request.Schema_Ventas.Pedidos;
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
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        public PedidoLlevarController(IMapper mapper)

        {
            _mapper = mapper;
            _pedidoLlevarBusiness = new PedidoLlevarBusiness(mapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CrearOrden([FromBody] OrdenLlevarRequest req)
        {
            var response = await _pedidoLlevarBusiness.CrearOrdenLlevar(req);
            return Ok(response);
        }
       
        /// <summary>
        /// Obtener todos los pedidos para llevar
        /// </summary>
        /// <returns>Lista de pedidos para llevar</returns>
        [HttpGet]
        [Route("PedidosLlevar")]
        public async Task<ActionResult<List<VwPedidoLlevar>>> GetPedidosLlevar()
        {
            var result = await _pedidoLlevarBusiness.ObtenerPedidosLlevar();
            return Ok(result);
        }

        /// <summary>
        /// Obtener el detalle de un pedido para llevar por ID
        /// </summary>
        /// <param name="idPedidoLlevar">ID del pedido para llevar</param>
        /// <returns>Detalle del pedido</returns>
        [HttpGet]
        [Route("DetallePedidoLlevar")]
        public async Task<ActionResult<List<VwDetPedidoLlevar>>> GetDetallePedidoLlevar([FromQuery] int idPedidoLlevar)
        {
            var result = await _pedidoLlevarBusiness.DetallePedidoLlevar(idPedidoLlevar);
            return Ok(result);
        }

        /// <summary>
        /// Marcar un pedido para llevar como listo
        /// </summary>
        /// <param name="idPedidoLlevar">ID del pedido para llevar</param>
        /// <returns>Respuesta de la operación</returns>
        [HttpPut]
        [Route("PedidoLlevarListo")]
        public async Task<ActionResult<CustomResponse>> PedidoLlevarListo([FromQuery] int idPedidoLlevar)
        {
            CustomResponse res = await _pedidoLlevarBusiness.PedidoLlevarListo(idPedidoLlevar);
            return Ok(res);
        }

        /// <summary>
        /// Cancelar un pedido para llevar
        /// </summary>
        /// <param name="idPedidoLlevar">ID del pedido para llevar</param>
        /// <returns>Respuesta de la operación</returns>
        [HttpDelete]
        [Route("CancelarPedidoLlevar")]
        public async Task<ActionResult<CustomResponse>> CancelarPedidoLlevar([FromQuery] int idPedidoLlevar)
        {
            CustomResponse res = await _pedidoLlevarBusiness.CancelarPedidoLlevar(idPedidoLlevar);
            return Ok(res);
        }
    }
}
