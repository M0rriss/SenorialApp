using AutoMapper;
using Business.Auth;
using Business.Schema_Usuarios.Usuarios;
using IBusiness.Auth;
using IBusiness.Schema_Usuarios.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UtilitySecurity.Encriptar;
using LoginRequest = RequestResponseModels.Request.Auth.LoginRequest;

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
        public AuthController(IMapper mapper) 
        {
            _mapper = mapper;
            _authBusiness = new AuthBusiness(mapper);
            _encriptar = new EncriptarDesencriptar();
            _usuarioBusiness = new UsuarioBusiness(mapper);
        }
        /// <summary>
        /// Metodo para realiar el inicio de sesion en el dashboard 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("LoginDash")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginDashboardResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> LoginDashboard([FromBody] LoginRequest request)
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
        public async Task<ActionResult> LoginEcommerce([FromBody] LoginRequest request)
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
        public async Task<ActionResult> LoginMobile([FromBody] LoginRequest request)
        {
            var loginResponse = _authBusiness.LoginMobile(request);

            if (loginResponse.Success) loginResponse.Token = await GenerateTokenMobile(loginResponse);

            return Ok(loginResponse);
        }
        [HttpPost, Route("ecommerce/registro")]
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

            return StatusCode(500, response); 
        }
        [HttpPost, Route("mobile/registro")]
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

            return StatusCode(500, response); 
        }






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
