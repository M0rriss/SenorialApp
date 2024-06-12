using AutoMapper;
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
        public LoginResponse LoginDashboard(LoginDashboardRequest request)
        {
            var result = new LoginResponse();
            UsuarioResponse usuario = _usuarioBusiness.BuscarPorUserName(request.UserName);
            if(usuario == null) return result;

            string newPassword = _encriptar.AES_encriptar(request.Password);
            if(newPassword != usuario.Password) return result;
            
            result.Success = true;
            result.Message = "Login Correcto";

            //result.RolName = new RolesResponse();
            //result.RolName.Nombre = usuario.Nombre;




            return result;

        }
    }
        #endregion
}
