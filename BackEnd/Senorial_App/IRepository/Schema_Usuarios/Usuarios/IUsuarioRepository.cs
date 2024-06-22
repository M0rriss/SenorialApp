using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Usuarios.Usuarios
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Usuario ObtenerPorCorreo(string email);
        Usuario ObtenerCorreoEccomerce(string email);
        Usuario ObtenerCorreoMobile(string email);
        Task<Usuario> RegistrarUsuarioEcommerce(Usuario usuario);
        Task<Usuario> RegistrarUsuarioMobile(Usuario usuario);
        Usuario ObtenerCodigoOtp(string email);
        Task<string> OneTimePass(string email, string codigo);
        List<UsuarioUiRequest> UiUsuarios();

        
    }
}
