using AutoMapper;
using Azure;
using Business.Schema_Usuarios.Roles;
using Business.Schema_Usuarios.Usuarios;
using DBSenorialModels.Senorial;
using DocumentFormat.OpenXml.Spreadsheet;
using IBusiness.Auth;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuarios;
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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.CrearToken;
using UtilitySecurity.Encriptar;

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
        public AuthBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBusiness = new UsuarioBusiness(mapper);
            _encriptar = new EncriptarDesencriptar();
            _rolesBusiness = new RolesBusiness(mapper);
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        #region JWT
        public async Task<string> GenerateToken(LoginUserRequest oLoginResponse)
        {
            
            int lifeTime = int.Parse(_configuration["Jwt:TimeJWT"]);
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, oLoginResponse.Email),

        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(lifeTime),
            signingCredentials: signIn
        );
            var tokenHandler = new JwtSecurityTokenHandler();
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }

        #endregion
        #endregion
        #region Logica
        public async Task<LoginDashboardResponse> LoginDashboard(LoginUserRequest request)
        {
            var result = new LoginDashboardResponse();
            UsuarioResponse usuario = await _usuarioBusiness.BuscarPorCorreo(request.Email);
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
            // Login exitoso
            result.Success = true;
            result.Message = "Login correcto";

            result.Usuario = new UsuarioResponse
            {
                Email = usuario.Email,
                IdRol = usuario.IdRol
            };

            return result;

        }

        public async Task<LoginEcommerceResponse> LoginEcommerce(LoginUserRequest request)
        {
            var result = new LoginEcommerceResponse();
            UsuarioResponse usuario = await _usuarioBusiness.BuscarCorreoEcommerce(request.Email);
            if (usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if (newPassword != usuario.Password) return result;

            result.Success = true;
            result.Message = "Login Correcto";

            result.Usuario = new UsuarioResponse { Email = request.Email };

            result.Token = await GenerateToken(request);


            return result;
        }

        public async Task<LoginMobileResponse> LoginMobile(LoginUserRequest request)
        {
            var result = new LoginMobileResponse();
            UsuarioResponse usuario = await _usuarioBusiness.BuscarCorreoMobile(request.Email);
            if (usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if (newPassword != usuario.Password) return result;

            result.Success = true;
            result.Message = "Login Correcto";

            result.Usuario = new UsuarioResponse { Email = request.Email };
            result.RolName = new RolesResponse { Nombre = "Empleado" };
            result.Token = await GenerateToken(request);
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
