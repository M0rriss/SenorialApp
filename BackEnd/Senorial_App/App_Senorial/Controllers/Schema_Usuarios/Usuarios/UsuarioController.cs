using AutoMapper;
using Business.Schema_Usuarios.Usuarios;
using IBusiness.Schema_Usuarios.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System.Net;

namespace App_Senorial.Controllers.Schema_Usuarios.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
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
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Get()
        {
            var userClaims = User.Claims;
            foreach (var claim in userClaims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }
            var result = _usuarioBusiness.GetUiUsuarios();
            return Ok(result);
        }
        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        //public async Task<ActionResult> Create([FromBody] UsuarioCreateRequest request)
        //{
        //    var result = await _usuarioBusiness.CreateUsuario(request);
        //    return Ok(result);
        //}
        /// <summary>
        /// Actualizar a los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Update([FromBody] UsuarioRequest request)
        {
            var result = await _usuarioBusiness.Update(request);
            return Ok(result);
        }
        /// <summary>
        /// Eliminar a los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _usuarioBusiness.Delete(id);
            return Ok(result);
        }
    }
}
