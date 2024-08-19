using CommonModels.Common;
using DBSenorialModels.View.Auth.Usuario;
using DBSenorialModels.View.Usuario.User;
using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.Filtro;
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
        Task<VwUsuario> BuscarPorCorreo(string email);
        Task<UsuarioResponse> BuscarCorreoEcommerce(string email);
        Task<UsuarioResponse> BuscarCorreoMobile(string email);
        Task<SignInEcommerceResponse> UsuarioRegistroEcommerce(SignInEcommerceRequest request);
        Task<SignInMobileResponse> UsuarioRegistroMoblie(SignInMobileRequest request);
        Task<bool> EnviarCodigoRecuperacionMovil(EnviarCodigoRecuperacionMovilRequest request);
        Task<bool> EnviarCodigoRecuperacionEcommerce(EnviarCodigoRecuperacionEcommerceRequest request);
        Task<UsuarioResponse> RestablecerContrasenaMovil(RestablecerPasswordMovilRequest request);
        Task<UsuarioResponse> RestablecerContrasenaEcommerce(RestablecerPasswordEcommerceRequest request);
        Task<UsuarioResponse> AutenticarConGoogleEcommerce(string tokenId);
        Task<UsuarioResponse> AutenticarConGoogleMobile(string tokenId);


        Task<List<UsuarioUiRequest>> GetUiUsuarios();
        Task<UsuarioUiResponse> InsertUiUsuarios(UsuarioUiRequest request);
        Task<UsuarioUiResponse> UpdateUiUsuarios(UsuarioUiUpdateRequest usuario);
        Task<bool> DeleteUiUser(int idUsuario);

        Task<GenericFilterResponse<VwUsuarios>> ListarUsuarioAsync(GenericFilterRequest req);

        Task<CustomResponse> CrearNuevoUsuarioAsync(UsuarioAddRequest req);
        Task<CustomResponse> ActulizarUsuarioAsync(UsuarioUpdateRequest req);
    }
}
