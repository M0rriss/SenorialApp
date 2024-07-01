using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace UtilitySecurity.CrearToken
{
    public class JwtTokenUtil
    {
        public static bool ValidateToken(string token, string secret)
        {
            var parts = token.Split('.');
            if (parts.Length != 3)
                return false;

            var header = DecodeBase64Url(parts[0]);
            var payload = DecodeBase64Url(parts[1]);
            var receivedSignature = parts[2];

            var calculatedSignature = CalculateSignature(parts[0], parts[1], secret);

            return receivedSignature.Equals(calculatedSignature);
        }

        private static string CalculateSignature(string header, string payload, string secret)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var base64UrlHeader = Base64UrlEncode(header);
            var base64UrlPayload = Base64UrlEncode(payload);
            var dataToSign = $"{base64UrlHeader}.{base64UrlPayload}";
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dataToSign));
            return Base64UrlEncode(hash);
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Base64UrlEncode(inputBytes);
        }

        private static string Base64UrlEncode(byte[] input)
        {
            return Convert.ToBase64String(input)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');
        }

        private static string DecodeBase64Url(string input)
        {
            var padding = input.Length % 4 == 0 ? 0 : 4 - (input.Length % 4);
            input = input.PadRight(input.Length + padding, '=');
            return Encoding.UTF8.GetString(Convert.FromBase64String(input.Replace('_', '/').Replace('-', '+')));
        }
        //public static string GenerateToken(string issuer, string audience, List<Claim> claims, string secret, int expiresInMinutes)
        //{
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        //    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: issuer,
        //        audience: audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
        //        signingCredentials: signIn
        //    );

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    return tokenHandler.WriteToken(token);
        //}
    }
}

