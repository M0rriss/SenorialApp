using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Usuarios;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Usuarios.Usuarios
{
    public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public Task<GenericFilterResponse<Usuario>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// DASHBOARD
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario ObtenerPorCorreo(string email)
        {
            var usuario = dbset.Where(x => x.Email.ToLower() == email.ToLower()).Include(x => x.IdRolNavigation.Nombre == "Admin" && x.IdRolNavigation.Nombre == "Cajera").FirstOrDefault();
            return usuario;
        }
        /// <summary>
        /// ECOMMERCE
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario ObtenerCorreoEccomerce(string email)
        {
            var usuario = dbset.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            return usuario;
        }
        /// <summary>
        /// MOBILE
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario ObtenerCorreoMobile(string email)
        {
          var usuario = dbset
         .Include(x => x.IdRolNavigation)  
         .Where(x => x.Email.ToLower() == email.ToLower() && x.IdRolNavigation.Nombre == "Empleado")
         .FirstOrDefault();
            return usuario;
        }

        public async Task<Usuario> RegistrarUsuarioEcommerce(Usuario usuario)
        {
            await dbset.AddAsync(usuario);
            usuario.Email = usuario.Email.ToLower();
            await db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> RegistrarUsuarioMobile(Usuario usuario)
        {
            await dbset.AddAsync(usuario);
            usuario.Email = usuario.Email.ToLower();
            await db.SaveChangesAsync();
            return usuario;
        }

        public Usuario ObtenerCodigoOtp(string email)
        {
          //hacer esto cuando el valor ya se encuentra en la BD
          var usuario = dbset        
         .Where(x => x.Email.ToLower() == email.ToLower())
         .FirstOrDefault();
           
            return usuario;
        }
        public async Task<string> OneTimePass(string email, string codigo)
        {
            // obtengo el email del usuario
          var usuario = dbset
         .Where(x => x.Email.ToLower() == email.ToLower())
         .FirstOrDefault();
            //del objeto usuario obtengo el codigo de recuperacion
            usuario.CodigoRecuperacion = codigo;
            db.Update(usuario);
            //guardo cambios
            await db.SaveChangesAsync();
            return codigo;
        }
    }
}
