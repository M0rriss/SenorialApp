using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace UtilitySecurity.CrearToken
{
    public class JwtTokenGenerator
    {
//        private readonly IConfiguration _configuration;

//        public JwtTokenGenerator(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public string GenerateToken(LoginResponse oLoginResponse)
//        {
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            string stringClaims = JsonConvert.SerializeObject(oLoginResponse);
//            stringClaims = _cripto.AES_encriptar(stringClaims);
//            var claims = new[]
//{
//                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                new Claim(ClaimTypes.Role, loginResponse.RolName.IdRol.ToString()),
//                new Claim("UserId", loginResponse.Usuario?.IdUsuarioAcceso.ToString()),
//                new Claim("UserName", loginResponse.Usuario?.Username),
//                new Claim("RoleName", loginResponse.RolName?.Descripcion),
//};

//            var token = new JwtSecurityToken(
//                _configuration["Jwt:Issuer"],
//                _configuration["Jwt:Audience"],
//                claims,
//                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:TimeJWTMin"])),
//                signingCredentials: signIn
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
    }
}
