using AutoMapper;
using Azure;
using Business.Schema_Usuarios.Roles;
using Business.Schema_Usuarios.Usuarios;
using IBusiness.Auth;
using IBusiness.Schema_Usuarios.Roles;
using IBusiness.Schema_Usuarios.Usuario;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Encriptar;

namespace Business.Auth
{
    public class AuthBusiness : IAuthBusiness
    {
        #region Dependency Innjection
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;
        private readonly RolesBusiness _rolesBusiness;
        private readonly EncriptarDesencriptar _encriptar;
        public AuthBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBusiness = new UsuarioBusiness(mapper);
            _encriptar = new EncriptarDesencriptar();
            _rolesBusiness = new RolesBusiness(mapper);
        }
        #endregion
        #region Logica
        public LoginDashboardResponse LoginDashboard(LoginUserRequest request)
        {
            var result = new LoginDashboardResponse();
            UsuarioResponse usuario = _usuarioBusiness.BuscarPorCorreo(request.Email);
            if(usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if(newPassword != usuario.Password) return result;
            
            result.Success = true;
            result.Message = "Login Correcto";

            result.Usuario = new UsuarioResponse { Email = request.Email };
            result.RolName = new RolesResponse { Nombre = "Admin" };

            return result;

        }

        public LoginEcommerceResponse LoginEcommerce(LoginUserRequest request)
        {
            var result = new LoginEcommerceResponse();
            UsuarioResponse usuario = _usuarioBusiness.BuscarCorreoEcommerce(request.Email);
            if (usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if (newPassword != usuario.Password) return result;

            result.Success = true;
            result.Message = "Login Correcto";

            result.Usuario = new UsuarioResponse { Email = request.Email };
            return result;
        }

        public LoginMobileResponse LoginMobile(LoginUserRequest request)
        {
            var result = new LoginMobileResponse();
            UsuarioResponse usuario = _usuarioBusiness.BuscarCorreoMobile(request.Email);
            if (usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if (newPassword != usuario.Password) return result;

            result.Success = true;
            result.Message = "Login Correcto";

            result.Usuario = new UsuarioResponse { Email = request.Email };
            result.RolName = new RolesResponse { Nombre = "Empleado" };

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
