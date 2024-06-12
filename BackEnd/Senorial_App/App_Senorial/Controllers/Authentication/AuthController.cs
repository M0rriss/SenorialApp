using AutoMapper;
using Business.Auth;
using IBusiness.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UtilitySecurity.Encriptar;

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
        private readonly IMapper _mapper;
        private readonly EncriptarDesencriptar _encriptar;
        public AuthController(IMapper mapper) 
        {
            _mapper = mapper;
            _authBusiness = new AuthBusiness(mapper);
            _encriptar = new EncriptarDesencriptar();
        }
        /// <summary>
        /// Valida que el servicio este activo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public ActionResult Get()
        {
            return Ok(true);
        }
        /// <summary>
        /// Metodo para realiar el inicio de sesion en el dashboard 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("LoginDash")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public async Task<ActionResult> LoginDashboard([FromBody] LoginDashboardRequest request)
        {
            var loginResponse = _authBusiness.LoginDashboard(request);

            if (loginResponse.Success) loginResponse.Token = await GenerateToken(loginResponse);

            return Ok(loginResponse);
        }
        #region JWT
        private Task<string> GenerateToken(LoginResponse loginResponse)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();
            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
            var claims = new[]
{
                     new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim(ClaimTypes.Role, loginResponse.RolName?.IdRol.ToString()),
                     new Claim("UserId", loginResponse.Usuario?.IdUsuario.ToString()),
                     new Claim("UserName", loginResponse.Usuario?.UserName),
                     new Claim("RoleName", loginResponse.RolName?.Descripcion),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
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
