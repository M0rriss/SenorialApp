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
        LoginDashboardResponse LoginDashboard(LoginUserRequest request);
        LoginEcommerceResponse LoginEcommerce(LoginUserRequest request);
        LoginMobileResponse LoginMobile(LoginUserRequest request);
        Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request);
        Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request);
    }
}
