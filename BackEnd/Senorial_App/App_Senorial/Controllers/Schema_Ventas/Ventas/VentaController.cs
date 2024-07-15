using AutoMapper;
using Business.Schema_Ventas.Ventas;
using IBusiness.Schema_Ventas.Ventas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.Ventas;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.Ventas;
using System.Net;

namespace App_Senorial.Controllers.Schema_Ventas.Ventas
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaBusiness _ventaBusiness;
        private  readonly IMapper _mapper;
        public VentaController(IMapper mapper)
        {
            _mapper = mapper;
            _ventaBusiness = new VentaBusiness(mapper);
        }
        #region CRUD METHODS

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<VentasResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetAllVentas()
        {
            var result = await _ventaBusiness.GetAllVentas();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VentasResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetVentaById(int id)
        {
            var result = await _ventaBusiness.GetVentaById(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VentasResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> CreateVenta([FromBody] VentasRequest ventaRequest)
        {
            var result = await _ventaBusiness.CreateVenta(ventaRequest);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VentasResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> UpdateVenta([FromBody] VentasRequest ventaRequest)
        {
            var result = await _ventaBusiness.UpdateVenta(ventaRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> DeleteVenta(int id)
        {
            var result = await _ventaBusiness.DeleteVenta(id);
            return Ok(result);
        }

        #endregion CRUD METHODS
    }
}
