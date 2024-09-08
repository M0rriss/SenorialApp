using DBSenorialModels.Senorial;
using DBSenorialModels.View.Auth.Usuario;
using DBSenorialModels.View.Usuario.User;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Generico.Filtro;
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
        Task<VwUsuario> ObtenerPorCorreo(string email);
        Usuario ObtenerCorreoEccomerce(string email);
        Usuario ObtenerCorreoMobile(string email);
        Task<Usuario> RegistrarUsuarioEcommerce(Usuario usuario);
        Task<Usuario> RegistrarUsuarioMobile(Usuario usuario);
        Task<Usuario> ObtenerCodigoOtp(string email);
        Task<string> OneTimePass(string email, string codigo);
        Task<List<UsuarioUiRequest>> UiUsuarios();

        Task<Usuario> InsertUiUsuarios(Usuario request);
        Task<Usuario> UpdateUiUsuarios(Usuario usuario);
        Task<bool> DeleteUiUsuarios(int id);
        Task<List<Usuario>> ObtenerPorPersonaId(int personaId);
        Task<VwUsuarioE> ObtenerPorCorreoE(string email);
        Task<GenericFilterResponse<VwUsuarios>> GetByFilterViewAsync(GenericFilterRequest request);

    }
}
