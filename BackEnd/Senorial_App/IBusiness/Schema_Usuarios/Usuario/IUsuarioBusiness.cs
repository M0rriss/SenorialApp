using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Schema_Usuarios.Usuario
{
    public interface IUsuarioBusiness : ICrudBusiness<UsuarioRequest, UsuarioResponse>
    {
        UsuarioResponse BuscarPorCorreo(string email);
        UsuarioResponse BuscarCorreoEcommerce(string email);
        UsuarioResponse BuscarCorreoMobile(string email);
        Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request);
        Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request);
    }
}
