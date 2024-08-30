using AutoMapper;
using Business.Schema_Ventas.TipoPedidos;
using IBusiness.Schema_Ventas.TipoPedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Ventas.TipoPedido;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Ventas.TipoPedido;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace App_Senorial.Controllers.Schema_Ventas.TipoPedido
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPedidoController : ControllerBase
    {
        #region Dependency Injection
        private readonly ITipoPedidoBusiness _tipoPedidoBusiness;
        private readonly IMapper _mapper;

        public TipoPedidoController(IMapper mapper)
        {
            _tipoPedidoBusiness = new TipoPedidoBusiness(mapper);
            _mapper = mapper;
        }
        #endregion

        #region CRUD METHODS
        [HttpGet, Route("Listado")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<TipoPedidoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> GetTipoPedido()
        {
            var response = await _tipoPedidoBusiness.GetAll();
            return Ok(response);
        }

   
        #endregion
    }
}
