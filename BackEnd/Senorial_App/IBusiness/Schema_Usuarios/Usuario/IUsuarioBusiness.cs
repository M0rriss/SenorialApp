using IBusiness.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
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
        UsuarioResponse BuscarPorUserName(string userName);
    }
}
