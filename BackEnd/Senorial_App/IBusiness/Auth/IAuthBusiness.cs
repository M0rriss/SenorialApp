using RequestResponseModels.Request.Auth;
using RequestResponseModels.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Auth
{
    public interface IAuthBusiness
    {
        Task<LoginDashboardResponse> LoginDashboard(LoginUserRequest request);
        Task<LoginEcommerceResponse> LoginEcommerce(LoginUserRequest request);
        Task<LoginMobileResponse> LoginMobile(LoginUserRequest request);
        Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request);
        Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request);


        Task<string> GenerateToken(LoginUserRequest oLoginResponse);
        //Task<string> GenerateTokenEcommerce(LoginUserRequest oLoginResponse);
        //Task<string> GenerateTokenMobile(LoginUserRequest oLoginResponse);

        



    }
}
