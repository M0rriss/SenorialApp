using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.Usuarios
{
    public interface IUsuarioBusiness : ICrudBusiness<UsuarioRequest, UsuarioResponse>
    {
        UsuarioResponse BuscarPorCorreo(string email);
        UsuarioResponse BuscarCorreoEcommerce(string email);
        UsuarioResponse BuscarCorreoMobile(string email);
        Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request);
        Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request);
        Task<bool> EnviarCodigoRecuperacionMovil(EnviarCodigoRecuperacionMovilRequest request);
        Task<bool> EnviarCodigoRecuperacionEcommerce(EnviarCodigoRecuperacionEcommerceRequest request);
        Task<UsuarioResponse> RestablecerContrasenaMovil(RestablecerPasswordMovilRequest request);
        Task<UsuarioResponse> RestablecerContrasenaEcommerce(RestablecerPasswordEcommerceRequest request);
        List<UsuarioUiRequest> GetUiUsuarios();
       


    }
}
