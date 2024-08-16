using AutoMapper;
using Business.Schema_Ventas.Mesas;
using Business.Schema_Ventas.Productos;
using IBusiness.Schema_Ventas.Mesas;
using IBusiness.Schema_Ventas.Productos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Mesas;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Mesas;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Mesas
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MesaController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IMesaBusiness _mesaBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public MesaController(IMapper mapper)
        {
            _mapper = mapper;
            _mesaBusiness = new MesaBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        #region CRUD METHODS
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA Mesa
        /// </summary>
        /// <returns>List-MesaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<MesaResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var result = await _mesaBusiness.GetAll();
            return Ok(result);
        }
        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>MesaResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MesaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _mesaBusiness.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA Mesa
        /// </summary>
        /// <param name="request">MesaRequest</param>
        /// <returns>MesaResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MesaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] MesaRequest request)
        {
            var result = await _mesaBusiness.Create(request);
            return Ok(result);
        }
        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA Mesa
        /// </summary>
        /// <param name="request">MesaRequest</param>
        /// <returns>MesaResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MesaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] MesaUpdateRequest request)
        {
            var result = await _mesaBusiness.UpdateMesa(request);
            return Ok(result);
        }
        /// <summary>
        /// ELIMINA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>cantidad de registros eliminados</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MesaResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mesaBusiness.Delete(id);
            return Ok(result);
        }
        #endregion CRUD METHODS

    }
}
