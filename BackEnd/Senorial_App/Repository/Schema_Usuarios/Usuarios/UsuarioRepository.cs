using DBSenorialModels.Senorial;
using DBSenorialModels.View.Auth.Usuario;
using DBSenorialModels.View.Usuario.User;
using IRepository.Schema_Usuarios.Usuarios;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
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
        public async Task<VwUsuario> ObtenerPorCorreo(string email)
        {
            VwUsuario list = new();
            var query = await (from user in dbset
                               join rol in db.Roles
                                   on user.IdRol equals rol.IdRol
                               join person in db.Personas
                                   on user.IdPersona equals person.IdPersona
                               where user.Email == email
                               select new
                               {
                                   user.IdPersona,
                                   user.IdRol,
                                   user.Email,
                                   Nombre = person.PrimerNombre + " " + person.ApellidoPaterno,
                                   Rol = rol.Nombre,
                                   user.Password,
                                   user.IdUsuario,
                               }).ToListAsync();

            foreach (var u in query)
            {
                list.Nombre = u.Nombre;
                list.Email = u.Email;
                list.IdPerson = u.IdPersona;
                list.IdRol = u.IdRol;
                list.Rol = u.Rol;
                list.Password = u.Password;
                list.IdUsuario = u.IdUsuario;
            }
            return list;

            //var query = await (from user in db.Usuarios
            //                   join rol in db.Roles
            //                       on user.IdRol equals rol.IdRol
            //                   join persona in db.Personas
            //                       on user.IdPersona equals persona.IdPersona
            //                   join empleado in db.Empleados
            //                       on persona.IdPersona equals empleado.IdPersona
            //                   where user.Email == email
            //                   select new VwUsuario
            //                   {
            //                       IdUsuario = user.IdUsuario,
            //                       Nombre = persona.PrimerNombre + " " + persona.ApellidoPaterno,
            //                       Rol = rol.Nombre,
            //                       IdRol = user.IdRol,
            //                       Password = user.Password,
            //                       Email = user.Email,
            //                       IdPerson = persona.IdPersona,
            //                       IdEmpleado = empleado.IdEmpleado // Asegúrate de obtener correctamente el IdEmpleado
            //                   }).FirstOrDefaultAsync();

            //return query;


            /*var usuario = dbset.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            return usuario;*/
        }
        public async Task<VwUsuarioE> ObtenerPorCorreoE(string email)
        {


            var query = await (from user in db.Usuarios
                               join rol in db.Roles
                                   on user.IdRol equals rol.IdRol
                               join persona in db.Personas
                                   on user.IdPersona equals persona.IdPersona
                               join empleado in db.Empleados
                                   on persona.IdPersona equals empleado.IdPersona
                               where user.Email == email
                               select new VwUsuarioE
                               {
                                   IdUsuario = user.IdUsuario,
                                   Nombre = persona.PrimerNombre + " " + persona.ApellidoPaterno,
                                   Rol = rol.Nombre,
                                   IdRol = user.IdRol,
                                   Password = user.Password,
                                   Email = user.Email,
                                   IdPerson = persona.IdPersona,
                                   IdEmpleado = empleado.IdEmpleado // Asegúrate de obtener correctamente el IdEmpleado
                               }).FirstOrDefaultAsync();

            return query;


            /*var usuario = dbset.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            return usuario;*/
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
         .Where(x => x.Email.ToLower() == email.ToLower())
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

        public async Task<Usuario> ObtenerCodigoOtp(string email)
        {
          //hacer esto cuando el valor ya se encuentra en la BD
          var usuario = dbset        
         .Where(x => x.Email.ToLower() == email.ToLower())
         .FirstOrDefault();
            await db.SaveChangesAsync();
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

        public async Task<List<UsuarioUiRequest>> UiUsuarios()
        {
            var datos = db.Usuarios
        .Join(db.Personas,
              u => u.IdPersona,
              p => p.IdPersona,
              (u, p) => new { u, p })
        .Join(db.Roles,
              up => up.u.IdRol,
              r => r.IdRol,
              (up, r) => new { up.u, up.p, r })
        .Select(upr => new UsuarioUiRequest
        {
            IdUsuario = upr.u.IdUsuario ,
            Nombres = upr.p.PrimerNombre + " " + upr.p.SegundoNombre + " " + upr.p.ApellidoPaterno + " " + upr.p.ApellidoMaterno,
            Correo = upr.p.Email,
            Telefono = upr.p.Telefono,
            Rol = upr.r.Nombre,
            Estado = upr.r.Estado
            
        })
        .ToList();
            return datos;
        }

        public async Task<Usuario> InsertUiUsuarios(Usuario usuario)
        {
            await dbset.AddAsync(usuario);
            usuario.Email = usuario.Email.ToLower();
            await db.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> UpdateUiUsuarios(Usuario usuario)
        {
            usuario.Email = usuario.Email.ToLower();
            dbset.Update(usuario);
            await db.SaveChangesAsync();
            return usuario;
        }
        public async Task<bool> DeleteUiUsuarios(int id)
        {
            var entity = await dbset.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity not found");
            }

            dbset.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<List<Usuario>> ObtenerPorPersonaId(int personaId)
        {
            return await db.Set<Usuario>().Where(u => u.IdPersona == personaId).ToListAsync();
        }
        #region MetodosUsuario
        private async Task<List<VwUsuarios>> ListarUsuarioAsync()
        {
            // Corregido: Inicializar la lista correctamente
            List<VwUsuarios> list = new List<VwUsuarios>();

            var query = await (from user in dbset
                               join rol in db.Roles
                                   on user.IdRol equals rol.IdRol
                               join persona in db.Personas
                                   on user.IdPersona equals persona.IdPersona
                               join empleado in db.Empleados
                                   on persona.IdPersona equals empleado.IdPersona
                               join img in db.Imagenes
                                   on user.IdImg equals img.Id
                               select new
                               {
                                   user.IdUsuario,
                                   Nombre = persona.PrimerNombre + " " + persona.ApellidoPaterno,
                                   Rol = rol.Nombre,
                                   rol.IdRol,
                                   user.Password,
                                   user.Email,
                                   persona.Telefono,
                                   Estado = true, // Esto puede ser un valor predeterminado o algo que calcules
                                   RutaImg = img.ImageData,
                                   // empleado.IdEmpleado // Agregar IdEmpleado
                               }).ToListAsync();

            foreach (var item in query)
            {
                VwUsuarios tmp = new VwUsuarios()
                {
                    IdUsuario = item.IdUsuario,
                    Nombre = item.Nombre,
                    Rol = item.Rol,
                    Telefono = item.Telefono,
                    Estado = item.Estado,
                    RutaImg = item.RutaImg,
                    Email = item.Email,
                    Password = item.Password,
                    IdRol = item.IdRol,
                    //IdEmpleado = item.IdEmpleado // Asignar el IdEmpleado correctamente
                };

                list.Add(tmp);
            }

            return list;
            //List<VwUsuarios> list = new List<VwUsuarios>();

            //var query = await (from user in dbset
            //                   join rol in db.Roles
            //                       on user.IdRol equals rol.IdRol
            //                   join persona in db.Personas
            //                       on user.IdPersona equals persona.IdPersona
            //                   join empleado in db.Empleados
            //                       on persona.IdPersona equals empleado.IdPersona
            //                   join img in db.Imagenes
            //                       on user.IdImg equals img.Id
            //                   select new VwUsuarios
            //                   {
            //                       IdUsuario = user.IdUsuario,
            //                       Nombre = persona.PrimerNombre + " " + persona.ApellidoPaterno,
            //                       Rol = rol.Nombre,
            //                       IdRol = user.IdRol,
            //                       Password = user.Password,
            //                       Email = user.Email,
            //                       Telefono = persona.Telefono,
            //                       Estado = true, // Si el estado es fijo, lo puedes dejar como está
            //                       RutaImg = img.ImageData,
            //                       IdEmpleado = empleado.IdEmpleado // Agregar IdEmpleado directamente
            //                   }).ToListAsync();

            //return query;

        }
        private async Task<List<VwUsuariosE>> ListarUsuarioEAsync()
        {

            List<VwUsuariosE> list = new List<VwUsuariosE>();

            var query = await (from user in dbset
                               join rol in db.Roles
                                   on user.IdRol equals rol.IdRol
                               join persona in db.Personas
                                   on user.IdPersona equals persona.IdPersona
                               join empleado in db.Empleados
                                   on persona.IdPersona equals empleado.IdPersona
                               join img in db.Imagenes
                                   on user.IdImg equals img.Id
                               select new VwUsuariosE
                               {
                                   IdUsuario = user.IdUsuario,
                                   Nombre = persona.PrimerNombre + " " + persona.ApellidoPaterno,
                                   Rol = rol.Nombre,
                                   IdRol = user.IdRol,
                                   Password = user.Password,
                                   Email = user.Email,
                                   Telefono = persona.Telefono,
                                   Estado = true, // Si el estado es fijo, lo puedes dejar como está
                                   RutaImg = img.ImageData,
                                   IdEmpleado = empleado.IdEmpleado // Agregar IdEmpleado directamente
                               }).ToListAsync();

            return query;
        }
        public async Task<GenericFilterResponse<VwUsuarios>> GetByFilterViewAsync(GenericFilterRequest request)
        {
            List<VwUsuarios> list = await ListarUsuarioAsync();
            var query = list.Where(x => x.IdUsuario == x.IdUsuario);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "Usuario":
                            query = query.Where(x => x.IdUsuario == int.Parse(j.Value));
                            break;
                    }
                }
            });

            GenericFilterResponse<VwUsuarios> res = new();

            res.TotalRegistros = query.Count();
            res.Lista = query
                //.Include(x => x.Status)
                .Skip((request.NumeroPagina - 1) * request.Cantidad)
                .Take(request.Cantidad)
                .OrderBy(x => x.IdUsuario)
                .ToList();

            return res;
        }
        #endregion MetodosUsuario
    }
}
