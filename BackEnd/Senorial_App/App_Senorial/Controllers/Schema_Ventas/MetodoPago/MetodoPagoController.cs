using AutoMapper;
using Business.Schema_Ventas.MetodoPagos;
using IBusiness.Schema_Ventas.MetodoPago;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.MetodoPago;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using System.Net;
using static RequestResponseModels.Request.Schema_Ventas.MetodoPago.MetodoPagoRequest;

namespace App_Senorial.Controllers.Schema_Ventas.MetodoPago
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        #region Dependency Injection
        private readonly IMetodoPagoBusiness _metodoPagoBusiness;
        private readonly IMapper _mapper;
        public MetodoPagoController(IMapper mapper)
        {
            _mapper = mapper;
            _metodoPagoBusiness = new MetodoPagoBusiness(mapper);
        }
        #endregion

        #region CRUD METHODS
        [HttpGet, Route("Listado")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<MetodoPagoUiResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UiGetMetodoPago()
        {
            var response = await _metodoPagoBusiness.UiGetMetodoPago();
            return Ok(response);
        }

        [HttpPost, Route("Crear")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MetodoPagoUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> InsertUiMetodoPago([FromBody] MetodoPagoUiRequest request)
        {
            var result = await _metodoPagoBusiness.InsertUiMetodoPago(request);
            return Ok(result);
        }

        [HttpPut, Route("Actualizar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MetodoPagoUiResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateUiMetodoPago([FromBody] MetodoPagoUpdateUiRequest request)
        {
            var result = await _metodoPagoBusiness.UpdateUiMetodoPago(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteUiMetodoPago(int id)
        {
            var result = await _metodoPagoBusiness.DeleteUiMetodoPago(id);
            return Ok(result);
        }
        #endregion
    }
}
