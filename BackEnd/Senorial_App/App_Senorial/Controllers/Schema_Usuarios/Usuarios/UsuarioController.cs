using AutoMapper;
using Business.Schema_Usuarios.Usuarios;
using CommonModels.Common;
using DBSenorialModels.View.Usuario.User;
using IBusiness.Schema_Usuarios.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System.Net;

namespace App_Senorial.Controllers.Schema_Usuarios.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        #region DECLARACION DE VARIABLE Y CONSTRUCTOR
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBusiness = new UsuarioBusiness(mapper);
        }
        #endregion DECLARACION DE VARIABLE Y CONSTRUCTOR
        /// <summary>
        /// Listar todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(CustomResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(CustomResponse))]
        public async Task<ActionResult<CustomResponse>> Get()
        {
            //var userClaims = User.Claims;
            var result = _usuarioBusiness.GetUiUsuarios();
            return StatusCode(200, result);
        }
        /// <summary>
        /// Crea a los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(CustomResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(CustomResponse))]
        public async Task<ActionResult<CustomResponse>> Create([FromBody] UsuarioUiRequest request)
        {
            var result = await _usuarioBusiness.InsertUiUsuarios(request);
            return StatusCode(200, result);
        }
        /// <summary>
        /// Actualizar a los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(CustomResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(CustomResponse))]
        public async Task<ActionResult<CustomResponse>> Update([FromBody] UsuarioUiUpdateRequest request)
        {
            var result = await _usuarioBusiness.UpdateUiUsuarios(request);
            return StatusCode(200, result);
        }
        /// <summary>
        /// Eliminar a los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(CustomResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(CustomResponse))]
        public async Task<ActionResult<CustomResponse>> Delete(int id)
        {
          var result =  await _usuarioBusiness.DeleteUiUser(id);
            return StatusCode(200, result);
        }

        [HttpPost]
        [Route("Filtro")]
        public async Task<ActionResult<GenericFilterResponse<VwUsuarios>>> FiltrarUsuarios([FromBody] GenericFilterRequest req)
        {
            GenericFilterResponse<VwUsuarios> res= await _usuarioBusiness.ListarUsuarioAsync(req);
            return Ok( res );
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<CustomResponse>> CrearNuevoUsuario([FromForm] UsuarioAddRequest req)
        {
            CustomResponse res = await _usuarioBusiness.CrearNuevoUsuarioAsync(req);
            return StatusCode(201, res );
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<CustomResponse>> ActulizarUsuario([FromForm] UsuarioUpdateRequest req)
        {
            CustomResponse res = await _usuarioBusiness.ActulizarUsuarioAsync(req);
            return StatusCode(200, res);
        }
    }
}
