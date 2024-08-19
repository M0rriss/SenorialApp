using AutoMapper;
using Azure;
using Business.Schema_Usuarios.Roles;
using Business.Schema_Usuarios.Usuarios;
using CommonModels.Common;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Spreadsheet;
using IBusiness.Auth;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.CrearToken;
using UtilitySecurity.Encriptar;
using Microsoft.AspNetCore.Authorization;
using DBSenorialModels.View.Auth.Usuario;
namespace Business.Auth
{
    public class AuthBusiness : IAuthBusiness
    {
        #region Dependency Innjection
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;
        private readonly IRolesBusiness _rolesBusiness;
        private readonly EncriptarDesencriptar _encriptar;
        private readonly IConfiguration _configuration;
        private readonly LoginGenericResponse _userDTO;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBusiness = new UsuarioBusiness(mapper);
            _encriptar = new EncriptarDesencriptar();
            _rolesBusiness = new RolesBusiness(mapper);
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _userDTO = new LoginGenericResponse();
            _httpContextAccessor = new HttpContextAccessor();
        }
        #region JWT
        public async Task<string> GenerateToken(LoginUserRequest oLoginResponse)
        {
            ClaimsIdentity claimsIdentity = new();
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, oLoginResponse.Email));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString()));//agregue
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, DateTime.UtcNow.ToString()));//agreuge

            int lifeTime = int.Parse(_configuration["Jwt:TimeJWT"]);
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var signIn = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokend = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(lifeTime),
                SigningCredentials = signIn
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokend);
            return await Task.FromResult(tokenHandler.WriteToken(createdToken));
        }
        private async Task<RefreshToken> GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7)
            };
            return refreshToken;
        }
        private async Task SetRefreshToken(RefreshToken newRefreshToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };

            httpContext.Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            _userDTO.RefreshToken = newRefreshToken.Token;
            _userDTO.TokenCreated = DateTime.UtcNow;
            _userDTO.TokenExpires = newRefreshToken.Expires;
        }
        #endregion
        #endregion
        #region Logica
        public async Task<LoginDashboardResponse> LoginDashboard(LoginUserRequest request)
        {
            var result = new LoginDashboardResponse();
            VwUsuario usuario = await _usuarioBusiness.BuscarPorCorreo(request.Email);
            //Validar Rol
            if (usuario.IdRol == 5) 
            {
                result.Success = false;
                result.Message = "No cuenta con permisos";
                return result;
            }
            if (usuario == null)
            {
                // Usuario no encontrado
                result.Success = false;
                result.Message = "Correo electrónico o contraseña incorrectos.";
                return result;
            }

            // Comparar contraseñas encriptadas
            string encryptedPassword = _encriptar.AES_encriptar(request.Password);
            if (encryptedPassword != usuario.Password)
            {
                // Contraseña incorrecta
                result.Success = false;
                result.Message = "Correo electrónico o contraseña incorrectos.";
                return result;
            }
            // Generar token JWT
            result.Token = await GenerateToken(request);

            var refreshToken = await GenerateRefreshToken();
            await SetRefreshToken(refreshToken);

            // Login exitoso
            result.Success = true;
            result.Message = "Login correcto";
            result.RefreshToken = refreshToken.Token;
            result.InfoUser = new()
            {
                IdPersona = usuario.IdPerson,
                Email = usuario.Email,
                IdRol = usuario.IdRol,
                Nombre= usuario.Nombre,
                Rol = usuario.Rol
            };

            return result;
        }

        public async Task<LoginEcommerceResponse> LoginEcommerce(LoginUserRequest request)
        {
            var result = new LoginEcommerceResponse();
            VwUsuario usuario = await _usuarioBusiness.BuscarPorCorreo(request.Email);
            if (usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if (newPassword != usuario.Password) return result;


            result.Token = await GenerateToken(request);
            var refreshToken = await GenerateRefreshToken();
            await SetRefreshToken(refreshToken);

            result.Success = true;
            result.Message = "Login Correcto";
            result.RefreshToken= refreshToken.Token;
            result.infoUsuario = new()
            {
                IdRol = usuario.IdRol,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                IdPersona = usuario.IdPerson,
                Rol = usuario.Rol
            };
            return result;
        }

        public async Task<LoginMobileResponse> LoginMobile(LoginUserRequest request)
        {
            var result = new LoginMobileResponse();
            UsuarioResponse usuario = await _usuarioBusiness.BuscarCorreoMobile(request.Email);
            if (usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if (newPassword != usuario.Password) return result;

            result.Token = await GenerateToken(request);
            var refreshToken = await GenerateRefreshToken();
            await SetRefreshToken(refreshToken);
            result.Success = true;
            result.Message = "Login Correcto";
            result.RefreshToken = refreshToken.Token;
            result.Usuario = new UsuarioResponse { Email = request.Email };
            result.RolName = new RolesResponse { Nombre = "Mozo" };
            return result;
        }

        public async Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request)
        {
            request.Password = _encriptar.AES_encriptar(request.Password);
            return await _usuarioBusiness.UsuarioRegistroEcommerce(request);
        }

        public async Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request)
        {
            return await _usuarioBusiness.UsuarioRegistroMoblie(request);
        }
    }
    #endregion
    

}
