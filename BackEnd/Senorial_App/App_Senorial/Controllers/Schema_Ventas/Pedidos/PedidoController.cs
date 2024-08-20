using AutoMapper;
using Business.Schema_Ventas.Pedidos;
using IBusiness.Schema_Ventas.Pedidos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Pedidos;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Pedidos;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Pedidos
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoBusiness _pedidoBusiness;
        private readonly IMapper _mapper;
        public PedidoController(IMapper mapper)
        {
            _mapper = mapper;
            _pedidoBusiness = new PedidoBusiness(mapper);
        }
        #region CRUD METHODS

        /// <summary>
        /// Retorna todos los registros de la tabla Pedido.
        /// </summary>
        /// <returns>Lista de respuestas de pedidos.</returns>
        /// <response code="200">Devuelve la lista de pedidos.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<PedidoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllPedidos()
        {
            var result = await _pedidoBusiness.GetAllPedidos();
            return Ok(result);
        }

        /// <summary>
        /// Retorna el registro de la tabla filtrado por el ID.
        /// </summary>
        /// <param name="id">ID del pedido.</param>
        /// <returns>Respuesta del pedido.</returns>
        /// <response code="200">Devuelve el pedido solicitado.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PedidoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetPedidoById(int id)
        {
            var result = await _pedidoBusiness.GetPedidoById(id);
            return Ok(result);
        }

        /// <summary>
        /// Inserta un nuevo registro en la tabla Pedido.
        /// </summary>
        /// <param name="request">Solicitud de creación de pedido.</param>
        /// <returns>Respuesta del pedido creado.</returns>
        /// <response code="200">Pedido creado exitosamente.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PedidoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreatePedido([FromBody] PedidoRequest request)
        {
            var result = await _pedidoBusiness.CreatePedido(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualiza un registro existente en la tabla Pedido.
        /// </summary>
        /// <param name="request">Solicitud de actualización de pedido.</param>
        /// <returns>Respuesta del pedido actualizado.</returns>
        /// <response code="200">Pedido actualizado exitosamente.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PedidoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdatePedido([FromBody] PedidoRequest request)
        {
            var result = await _pedidoBusiness.UpdatePedido(request);
            return Ok(result);
        }

        /// <summary>
        /// Elimina un registro de la tabla Pedido.
        /// </summary>
        /// <param name="id">ID del pedido a eliminar.</param>
        /// <returns>Resultado de la eliminación.</returns>
        /// <response code="200">Pedido eliminado exitosamente.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeletePedido(int id)
        {
            var result = await _pedidoBusiness.DeletePedido(id);
            return result ? Ok() : BadRequest(new GenericResponse { Mensaje = "Pedido no encontrado" });
        }

        #endregion CRUD METHODS
    }
}
