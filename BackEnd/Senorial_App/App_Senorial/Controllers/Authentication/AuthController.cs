using AutoMapper;
using Business.Auth;
using Business.Schema_Usuarios.Personas;
using Business.Schema_Usuarios.Roles;
using Business.Schema_Usuarios.Usuarios;
using CommonModels.Common;
using IBusiness.Auth;
using IBusiness.Schema_Usuarios.Personas;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuario;
using IRepository.Schema_Usuarios.Personas;
using IRepository.Schema_Usuarios.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Schema_Usuarios.Personas;
using Repository.Schema_Usuarios.Roles;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UtilitySecurity.Encriptar;
using LoginUserRequest = RequestResponseModels.Request.Auth.LoginUserRequest;

namespace App_Senorial.Controllers.Authentication
{
    /// <summary>
    /// Metodos para LOG IN
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;
        private readonly EncriptarDesencriptar _encriptar;
        private readonly IPersonaBusiness _personaBusiness;
        private readonly IRolesBusiness _rolesBusiness;
        public AuthController(IMapper mapper) 
        {
            _mapper = mapper;
            _authBusiness = new AuthBusiness(mapper);
            _encriptar = new EncriptarDesencriptar();
            _usuarioBusiness = new UsuarioBusiness(mapper);
            _personaBusiness = new PersonaBusiness(mapper);
            _rolesBusiness = new RolesBusiness(mapper);
        }
        #region LOGIN
        /// <summary>
        /// Metodo para realizar el inicio de sesion en el dashboard 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("LoginDash")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginDashboardResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> LoginDashboard([FromBody] LoginUserRequest request)
        {
            var loginResponse = _authBusiness.LoginDashboard(request);

            if (loginResponse.Success) loginResponse.Token = await GenerateTokenDashboard(loginResponse);

            return Ok(loginResponse);
        }
        /// <summary>
        /// Metodo para realizar el inicio de sesion en el Eccomerce 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("Login/Ecommerce")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginEcommerceResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> LoginEcommerce([FromBody] LoginUserRequest request)
        {
            var loginResponse = _authBusiness.LoginEcommerce(request);
            if (loginResponse.Success) loginResponse.Token = await GenerateTokenEcommerce(loginResponse);
            return Ok(loginResponse);
        }
        /// <summary>
        /// Metodo para realizar el inicio de sesion en el Mobile
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("Login/Mobile")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> LoginMobile([FromBody] LoginUserRequest request)
        {
            var loginResponse = _authBusiness.LoginMobile(request);
            if (loginResponse.Success) loginResponse.Token = await GenerateTokenMobile(loginResponse);
            return Ok(loginResponse);
        }
        #endregion
        #region REGISTRO
        /// <summary>
        /// Metodo para realizar el registro en el Ecommerce
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("ecommerce/registro")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<CustomResponse>> SignInUsuarioEcommerce([FromBody] SignInEcommerceRequest req)
        {
            if (req == null)
            {
                return BadRequest("NO DEBE CONTENER ESPACION EN BLANCO");
            }
           
            var response = await _usuarioBusiness.UsuarioRegistroEcommerce(req);

            return Ok(response); 
        }
        /// <summary>
        /// Metodo para realizar el registro en el Mobile
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("mobile/registro")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<CustomResponse>> SignInUsuarioMobile([FromBody] SignInMobileRequest req)
        {
            if (req == null)
            {
                return BadRequest("NO DEBE CONTENER ESPACION EN BLANCO");
            }

            var response = await _usuarioBusiness.UsuarioRegistroMoblie(req);

            return Ok(response);
        }
        #endregion

        #region RECUPERAR PASSWORD
        /// <summary>
        /// Metodo para realizar el envio del codigo OTP en el Mobile
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SendRecoveryCode/movil")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<CustomResponse>> EnviarCodigoRecuperacionMovil([FromBody] EnviarCodigoRecuperacionMovilRequest request)
        {
            bool result = await _usuarioBusiness.EnviarCodigoRecuperacionMovil(request);

            if (result)
            {
                return Ok(new CustomResponse
                {
                    Code = "200",
                    Message = "Código de recuperación enviado al correo electrónico."
                });
            }
            else
            {
                return NotFound(new CustomResponse
                {
                    Code = "404",
                    Message = "Correo electrónico no registrado."
                });
            }
        }
        /// <summary>
        /// Metodo para realizar el envio del codigo OTP en el Ecommerce
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SendRecoveryCode/ecommerce")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<CustomResponse>> EnviarCodigoRecuperacionEcommerce([FromBody] EnviarCodigoRecuperacionEcommerceRequest request)
        {
            bool result = await _usuarioBusiness.EnviarCodigoRecuperacionEcommerce(request);

            if (result)
            {
                return Ok(new CustomResponse
                {
                    Code = "200",
                    Message = "Código de recuperación enviado al correo electrónico."
                });
            }
            else
            {
                return NotFound(new CustomResponse
                {
                    Code = "404",
                    Message = "Correo electrónico no registrado."
                });
            }
        }
        /// <summary>
        /// Metodo para actualizar la contraseña del Mobile
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("RecoveryPassword/movil")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<CustomResponse>> RestablecerContrasenaMovil([FromBody] RestablecerPasswordMovilRequest request)
        {
           // Llamar al método de negocio para restablecer la contraseña
            var result = await _usuarioBusiness.RestablecerContrasenaMovil(request);
            // Retornar una respuesta exitosa si no hay excepciones
            return Ok(new CustomResponse
            {
                Code = "200",
                Message = "Contraseña restablecida exitosamente."
            });
        }
        /// <summary>
        /// Metodo para actualizar la contraseña del Ecommerce
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("RecoveryPassword/ecommerce")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult<CustomResponse>> RestablecerContrasenaEcommerce([FromBody] RestablecerPasswordEcommerceRequest request)
        {
            // Llamar al método de negocio para restablecer la contraseña
            var result = await _usuarioBusiness.RestablecerContrasenaEcommerce(request);
            // Retornar una respuesta exitosa si no hay excepciones
            return Ok(new CustomResponse
            {
                Code = "200",
                Message = "Contraseña restablecida exitosamente."
            });
        }
            #endregion


            #region JWT
        private Task<string> GenerateTokenDashboard(LoginDashboardResponse oLoginResponse)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
{
                     new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim(ClaimTypes.Role, oLoginResponse.RolName?.IdRol.ToString()),
                     new Claim("UserId", oLoginResponse.Usuario?.IdUsuario.ToString()),
                     new Claim("UserName", oLoginResponse.Usuario?.UserName),
                     new Claim(ClaimTypes.Email, oLoginResponse.Usuario.Email.ToString()),
                     new Claim("RoleName", oLoginResponse.RolName?.Descripcion),
                };

            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(tiempoVida),
                signingCredentials: signIn
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
        private Task<string> GenerateTokenEcommerce(LoginEcommerceResponse oLoginResponse)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
{
                     new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim("UserId", oLoginResponse.Usuario?.IdUsuario.ToString()),
                     new Claim("UserName", oLoginResponse.Usuario?.UserName),
                     new Claim(ClaimTypes.Email, oLoginResponse.Usuario.Email.ToString()),
                };

            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(tiempoVida),
                signingCredentials: signIn
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
        private Task<string> GenerateTokenMobile(LoginMobileResponse oLoginResponse)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
{
                     new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim(ClaimTypes.Role, oLoginResponse.RolName?.IdRol.ToString()),
                     new Claim("UserId", oLoginResponse.Usuario?.IdUsuario.ToString()),
                     new Claim("UserName", oLoginResponse.Usuario?.UserName),
                     new Claim(ClaimTypes.Email, oLoginResponse.Usuario.Email.ToString()),
                     new Claim("RoleName", oLoginResponse.RolName?.Descripcion),
                };

            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(tiempoVida),
                signingCredentials: signIn
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
        #endregion
    }
}
