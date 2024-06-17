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
        /// Metodo para realiar el inicio de sesion en el dashboard 
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
        /// Metodo para realiar el inicio de sesion en el Eccomerce 
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
        /// Metodo para realiar el inicio de sesion en el Mobile
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
        [HttpPost, Route("ecommerce/registro")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> SignInUsuarioEcommerce([FromBody] SignInEcommerceRequest req)
        {
            if (req == null)
            {
                return BadRequest("NO DEBE CONTENER ESPACION EN BLANCO");
            }
           
            var response = await _usuarioBusiness.UsuarioRegistroEcommerce(req);

            //if (response.Success)
            //{
            //    return StatusCode(201, response);
            //}

            return Ok(response); 
        }
        [HttpPost, Route("mobile/registro")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginMobileResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> SignInUsuarioMobile([FromBody] SignInMobileRequest req)
        {
            if (req == null)
            {
                return BadRequest("NO DEBE CONTENER ESPACION EN BLANCO");
            }

            var response = await _usuarioBusiness.UsuarioRegistroMoblie(req);

            //if (response.Success)
            //{
            //    return StatusCode(201, response);
            //}

            return Ok(response);
        }
        #endregion

        #region RECUPERAR PASSWORD

        [HttpPost("SendRecoveryCode/movil")]
        public async Task<ActionResult<CustomResponse>> EnviarCodigoRecuperacionMovil([FromBody] EnviarCodigoRecuperacionMovilRequest request)
        {
            await _usuarioBusiness.EnviarCodigoRecuperacionMovil(request);

            return Ok(new CustomResponse
            {
                Code = "200",
                Message = "Código de recuperación enviado al correo electronico."
            });
        }

        [HttpPost("SendRecoveryCode/ecommerce")]
        public async Task<ActionResult<CustomResponse>> EnviarCodigoRecuperacionEcommerce([FromBody] EnviarCodigoRecuperacionEcommerceRequest request)
        {
            await _usuarioBusiness.EnviarCodigoRecuperacionEcommerce(request);
            return Ok(new CustomResponse { Code = "200", Message = "Código de recuperación enviado por correo electrónico." });
        }

        [HttpPut("RecoveryPassword/movil")]
        public async Task<ActionResult<CustomResponse>> RestablecerContrasenaMovil([FromBody] RestablecerPasswordMovilRequest request)
        {
            await _usuarioBusiness.RestablecerContrasenaMovil(request);
            return Ok(new CustomResponse { Code = "200", Message = "Contraseña restablecida correctamente." });
        }

        [HttpPut("RecoveryPassword/ecommerce")]
        public async Task<ActionResult<CustomResponse>> RestablecerContrasenaEcommerce([FromBody] RestablecerPasswordEcommerceRequest request)
        {
            await _usuarioBusiness.RestablecerContrasenaEcommerce(request);
            return Ok(new CustomResponse { Code = "200", Message = "Contraseña restablecida correctamente." });
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
