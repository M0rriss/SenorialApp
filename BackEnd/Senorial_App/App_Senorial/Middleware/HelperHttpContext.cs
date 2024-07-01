using CommonModels.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace App_Senorial.Middleware
{
    public class HelperHttpContext : IHelperHttpContext
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public InfoRequest GetInfoRequest(HttpContext request)
        {
            InfoRequest obj = new InfoRequest();
            obj.Claims = GetTokenClaims(request);
            obj.RequestHttp = GetHttpContextInfo(request);
            return obj;
        }
        #region ClaseFranklin
        //private TokenClaims GetTokenClaims(HttpContext request)
        //{
        //    TokenClaims obj = new TokenClaims();
        //    string autorizacion = request.Request.Headers[HeaderNames.Authorization];
        //    if (autorizacion != null)
        //    {
        //        var identity = request.User.Identity as ClaimsIdentity;
        //        if (identity != null)
        //        {
        //            IEnumerable<Claim> claims = identity.Claims;
        //            obj.Role = identity.Claims.
        //                Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
        //            obj.Nombre =
        //                identity.Claims.Where(c => c.Type == "DisplayName").Select(c => c.Value).SingleOrDefault();

        //            obj.UserId = int.Parse(identity.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault());
        //            obj.UserName = identity.Claims.Where(c => c.Type == "UserName").Select(c => c.Value).SingleOrDefault();
        //            obj.UserName = identity.Claims.Where(c => c.Type == "RoleName").Select(c => c.Value).SingleOrDefault();
        //        }
        //    }
        //    return obj;
        //}
        //private ApiRequestContext GetHttpContextInfo(HttpContext request)
        //{
        //    ApiRequestContext obj = new ApiRequestContext();
        //    obj.AbsolutePath = request.Request.GetEncodedUrl(); ;
        //    obj.AbsoluteUri = request.Request.GetEncodedPathAndQuery();
        //    obj.Ip = request.Connection.RemoteIpAddress.ToString();
        //    obj.Method = $"{request.Request.Method}";
        //    obj.UserAgent = request.Request.Headers[HeaderNames.UserAgent];
        //    obj.Controller = request.GetEndpoint().DisplayName;
        //    obj.Host = request.Request.Headers[HeaderNames.Host];
        //    try
        //    {
        //        var reader = new StreamReader(request.Request.Body);
        //        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        //        obj.BodyRequest = reader.ReadToEnd();
        //    }
        //    catch (Exception)
        //    {
        //        obj.BodyRequest = "";
        //    }
        //    return obj;
        //}
        #endregion
        #region Prueba
        private TokenClaims GetTokenClaims(HttpContext request)
        {
            TokenClaims obj = new TokenClaims();
            string autorizacion = request.Request.Headers[HeaderNames.Authorization];
            if (!string.IsNullOrEmpty(autorizacion))
            {
                var identity = request.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    obj.Role = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value)
                        .SingleOrDefault();
                    obj.Nombre = identity.Claims
                        .Where(c => c.Type == "DisplayName")
                        .Select(c => c.Value)
                        .SingleOrDefault();
                    obj.UserId = int.Parse(identity.Claims
                        .Where(c => c.Type == "UserId")
                        .Select(c => c.Value)
                        .SingleOrDefault() ?? "0");
                    obj.UserName = identity.Claims
                        .Where(c => c.Type == "UserName")
                        .Select(c => c.Value)
                        .SingleOrDefault();
                    obj.RoleName = identity.Claims
                        .Where(c => c.Type == "RoleName")
                        .Select(c => c.Value)
                        .SingleOrDefault();
                }
            }
            return obj;
        }
        private ApiRequestContext GetHttpContextInfo(HttpContext request)
        {
            ApiRequestContext obj = new ApiRequestContext
            {
                AbsolutePath = request.Request.GetEncodedUrl(),
                AbsoluteUri = request.Request.GetEncodedPathAndQuery(),
                Ip = request.Connection.RemoteIpAddress.ToString(),
                Method = request.Request.Method,
                UserAgent = request.Request.Headers[HeaderNames.UserAgent],
                Controller = request.GetEndpoint()?.DisplayName,
                Host = request.Request.Headers[HeaderNames.Host]
            };
            try
            {
                var reader = new StreamReader(request.Request.Body);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                obj.BodyRequest = reader.ReadToEnd();
            }
            catch (Exception)
            {
                obj.BodyRequest = string.Empty;
            }
            return obj;
        }
        #endregion
    }
}
