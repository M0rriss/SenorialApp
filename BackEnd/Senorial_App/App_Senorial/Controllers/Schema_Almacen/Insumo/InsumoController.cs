using AutoMapper;
using Business.Schema_Almacen.Insumos;
using Business.Schema_Generico.UnidadMediciones;
using CommonModels.Common;
using IBusiness.Schema_Almacen.Insumos;
using IBusiness.Schema_Generico.UnidadMediciones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.Net;

namespace App_Senorial.Controllers.Schema_Almacen.Insumo
{
    
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InsumoController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IInsumoBusiness _insumoBusiness;
        private readonly IUnidadMedicionBusiness _unidadMedicionBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public InsumoController(IMapper mapper)
        {
            _mapper = mapper;
            _insumoBusiness = new InsumoBusiness(mapper);
            _unidadMedicionBusiness = new UnidadMedicionBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        #region CRUD METHODS
        [HttpGet, Route("Listado")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<InsumoUiResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UiGetInsumo()
        {
            var response = await _insumoBusiness.UiGetInsumo();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(InsumoUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _insumoBusiness.GetById(id);
            return Ok(result);
        }

        [HttpPost, Route("Crear/Insumo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(InsumoUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Create([FromBody] InsumoUiRequest request)
        {
            var result = await _insumoBusiness.InsertUiInsumo(request);
            return Ok(result);
        }

        [HttpPut, Route("Actualizar/Insumo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(InsumoUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] InsumoUpdateUiRequest request)
        {
            var result = await _insumoBusiness.UpdateUiInsumo(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _insumoBusiness.DeleteUiInsumo(id);
            return Ok(result);
        }
        #endregion CRUD METHODS
        #region POST
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Filtro")]
        public async Task<ActionResult<GenericFilterResponse<InsumoUiRequest>>> FiltroProductos([FromBody] GenericFilterRequest req)
        {
            GenericFilterResponse< InsumoUiRequest > res = await _insumoBusiness.FiltroInsumoAsync(req);
            return Ok(res);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<CustomResponse>> RegistarInsumo([FromBody] InsumoRequest req)
        {
            CustomResponse res = await _insumoBusiness.CrearInsumoAsync(req);
            return StatusCode(201,res);
        }
        [HttpPut]
        [Route("Actulizar")]
        public async Task<ActionResult<CustomResponse>> ActulizarInsumo([FromBody] InsumoRequest req)
        {
            CustomResponse res = await _insumoBusiness.ActulizarInsumoAsync(req);
            return StatusCode(200, res);
        }
        #endregion POST
    }
}
