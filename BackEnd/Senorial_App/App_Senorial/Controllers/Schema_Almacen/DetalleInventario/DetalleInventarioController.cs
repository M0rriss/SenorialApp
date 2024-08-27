using AutoMapper;
using Business.Schema_Almacen.DetalleInventarios;
using CommonModels.Common;
using DBSenorialModels.View.Almacen;
using DBSenorialModels.View.Almacen.DetalleIngreso;
using DocumentFormat.OpenXml.Wordprocessing;
using IBusiness.Schema_Almacen.DetalleInventarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Response.Schema_Generico.Filtro;

namespace App_Senorial.Controllers.Schema_Almacen.DetalleInventario
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleInventarioController : ControllerBase
    {

        private readonly IDetalleInventarioBusiness _detalleInventarioBusiness;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public DetalleInventarioController(IMapper mapper) 
        {
            _detalleInventarioBusiness = new DetalleInventarioBusiness();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idInsumo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(template: "Buscar")]
        public async Task<ActionResult<VwBuscarInsumoDetalle>> BuscarInsumo([FromQuery] int idInsumo)
        {
            VwBuscarInsumoDetalle res = await _detalleInventarioBusiness.BuscarSuministroAsync(idInsumo);
            return StatusCode(200,res);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(template: "Listar")]
        public async Task<ActionResult<GenericFilterResponse<VwDetalleIngreos>>> ListarDetalleIngreso([FromQuery]int page=1, int pagesize=10, string insumo = null!)
        {
            GenericFilterResponse<VwDetalleIngreos> res = await _detalleInventarioBusiness.ListarInventarioAsync(page,pagesize, insumo);
            return StatusCode(200,res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(template: "Detalle")]
        public async Task<ActionResult<GenericFilterResponse<VwDetalleInsumos>>> ListarDetalle([FromQuery] int page = 1, int pagesize = 10, string insumo = null!)
        {
            GenericFilterResponse<VwDetalleInsumos> res = await _detalleInventarioBusiness.ListarDetalleInventario(page, pagesize, insumo);
            return StatusCode(200, res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idInsumo"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(template: "Eliminar")]
        public async Task<ActionResult<CustomResponse>> EliminarDetallete([FromQuery] int idInsumo)
        {
            CustomResponse res = await _detalleInventarioBusiness.EliminarInsumo(idInsumo);
            return StatusCode(200, res);
        }
    }
}
