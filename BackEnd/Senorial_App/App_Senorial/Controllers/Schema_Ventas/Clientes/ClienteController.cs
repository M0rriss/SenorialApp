using AutoMapper;
using Business.Schema_Almacen.Categorias;
using Business.Schema_Ventas.Clientes;
using IBusiness.Schema_Almacen.Categorias;
using IBusiness.Schema_Ventas.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Cliente;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IClienteBusiness _clienteBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
            _clienteBusiness = new ClienteBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA CLIENTES
        /// </summary>
        /// <returns>List-CategoriaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ClienteResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result = await _clienteBusiness.UiGetCliente();
            return Ok(result);
        }
        /// <summary>
        /// Inserta un nuevo cliente.
        /// </summary>
        /// <param name="cliente">Datos del cliente a insertar.</param>
        /// <returns>ClienteUiRequest insertado.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] ClienteUiRequest request)
        {
            var clienteInsertado = await _clienteBusiness.InsertUiCliente(request);
            return Ok(clienteInsertado);
        }

        /// <summary>
        /// Actualiza un cliente existente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id">ID del cliente a actualizar.</param>
        /// <param name="cliente">Datos actualizados del cliente.</param>
        /// <returns>ClienteUiRequest actualizado.</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] ClienteUpdateUiRequest request)
        {
           
            var clienteActualizado = await _clienteBusiness.UpdateUiCliente(request);
            return Ok(clienteActualizado);
        }

        /// <summary>
        /// Elimina un cliente existente por ID.
        /// </summary>
        /// <param name="id">ID del cliente a eliminar.</param>
        /// <returns>Respuesta de éxito.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<GenericResponse>> Delete(int id)
        {
            await _clienteBusiness.DeleteUiCliente(id);
            return Ok("Cliente deleted successfully.");
        }
    }
}
