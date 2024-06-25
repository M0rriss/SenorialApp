using DBSenorialModels.Senorial;
using IRepository.Schema_Usuarios.Usuarios;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Auth.Recuperacion;
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
        public Usuario ObtenerPorCorreo(string email)
        {
            var usuario = dbset.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
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

        public List<UsuarioUiRequest> UiUsuarios()
        {
            var datos =  db.Usuarios
                . Join(db.Personas,
                      u => u.IdPersona,
                      p => p.IdPersona,
                      (u, p) => new { u, p })
                .Join(db.Roles,
                      up => up.u.IdRol,
                      r => r.IdRol,
                      (up, r) => new { up.u, up.p, r })
                .Join(db.Estados,
                      upr => upr.r.IdEstado,
                      e => e.IdEstado,
                      (upr, e) => new UsuarioUiRequest
                      {
                          Nombres = upr.p.PrimerNombre + " " + upr.p.SegundoNombre + " " + upr.p.ApellidoPaterno + " " + upr.p.ApellidoMaterno,
                          Correo = upr.p.Email,
                          Telefono = upr.p.Telefono,
                          Rol = upr.r.Nombre,
                          Estado = e.Nombre
                      })
                .ToList();
            return datos;
        }

        public async Task<UsuarioUiRequest> InsertUiUsuarios(UsuarioUiRequest request)
        {
                // Dividir el campo Nombres en sus componentes individuales
                var nombres = request.Nombres.Split(' ');
                if (nombres.Length < 2)
                {
                    throw new ArgumentException("El campo Nombres debe contener al menos un nombre y un apellido.");
                }

                var primerNombre = nombres[0];
                var segundoNombre = nombres.Length > 1 ? nombres[1] : "";
                var apellido = nombres[nombres.Length - 1];

                // Crear una nueva instancia de Persona
                var nuevaPersona = new Persona
                {
                    PrimerNombre = primerNombre,
                    SegundoNombre = segundoNombre,
                    ApellidoPaterno = apellido,
                    ApellidoMaterno = "",
                    Email = request.Correo,
                    Telefono = request.Telefono
                };

                // Agregar la nueva persona a la base de datos
                await db.Personas.AddAsync(nuevaPersona);
                await db.SaveChangesAsync();

                // Obtener el IdPersona recién insertado
                var idPersona = nuevaPersona.IdPersona;

                // Obtener el IdRol basado en el nombre proporcionado
                var rol = await db.Roles.FirstOrDefaultAsync(r => r.Nombre == request.Rol);
                if (rol == null)
                {
                    throw new ArgumentException("Rol no encontrado.");
                }

                // Obtener el estado "Activo" por defecto
                var estadoActivo = await db.Estados.FirstOrDefaultAsync(e => e.IdEstado == 2); // IdEstado = 2 para "Activo"

                if (estadoActivo == null)
                {
                    throw new ArgumentException("Estado 'Activo' no encontrado.");
                }

                // Crear una nueva instancia de Usuario
                var nuevoUsuario = new Usuario
                {
                    IdPersona = idPersona,
                    IdRol = rol.IdRol,
                    Email = request.Correo,
                    UserName = request.Correo.ToLower(),
                    CambiarPassword = "",
                };

                // Agregar el nuevo usuario a la base de datos
                await db.Usuarios.AddAsync(nuevoUsuario);
                await db.SaveChangesAsync();

                // Crear y devolver el objeto de respuesta
                return new UsuarioUiRequest
                {
                    Nombres = request.Nombres,
                    Correo = request.Correo,
                    Telefono = request.Telefono,
                    Rol = request.Rol,
                    Estado = estadoActivo.Nombre // Devolver el nombre del estado "Activo"
                };
            

            //// Dividir el campo Nombres en sus componentes individuales
            //var nombres = request.Nombres.Split(' ');
            //if (nombres.Length < 2)
            //{
            //    throw new ArgumentException("El campo Nombres debe contener al menos un nombre y un apellido.");
            //}

            //var primerNombre = nombres[0];
            //var segundoNombre = nombres.Length > 1 ? nombres[1] : "";
            //var apellido = nombres[nombres.Length - 1];

            //// Crear una nueva instancia de Persona
            //var nuevaPersona = new Persona
            //{
            //    PrimerNombre = primerNombre,
            //    SegundoNombre = segundoNombre,
            //    ApellidoPaterno = apellido,
            //    ApellidoMaterno = "",
            //    Email = request.Correo,
            //    Telefono = request.Telefono
            //};

            //// Agregar la nueva persona a la base de datos
            //await db.Personas.AddAsync(nuevaPersona);
            //await db.SaveChangesAsync();

            //// Obtener el IdPersona recién insertado
            //var idPersona = nuevaPersona.IdPersona;

            //// Obtener el IdRol basado en el nombre proporcionado
            //var rol = await db.Roles.FirstOrDefaultAsync(r => r.Nombre == request.Rol);
            //if (rol == null)
            //{
            //    throw new ArgumentException("Rol no encontrado.");
            //}

            //// Crear una nueva instancia de Usuario
            //var nuevoUsuario = new Usuario
            //{
            //    IdPersona = idPersona,
            //    IdRol = rol.IdRol,
            //    Email = request.Correo,
            //    UserName = request.Correo.ToLower(),
            //    CambiarPassword = "",
            //};

            //// Agregar el nuevo usuario a la base de datos
            //await db.Usuarios.AddAsync(nuevoUsuario);
            //await db.SaveChangesAsync();



            //var datos = await db.Usuarios
            //        .Join(db.Personas,
            //              u => u.IdPersona,
            //              p => p.IdPersona,
            //              (u, p) => new { u, p })
            //        .Join(db.Roles,
            //              up => up.u.IdRol,
            //              r => r.IdRol,
            //              (up, r) => new { up.u, up.p, r })
            //        .Join(db.Estados,
            //              upr => upr.r.IdEstado,
            //              e => e.IdEstado,
            //              (upr, e) => new UsuarioUiRequest
            //              {
            //                  Nombres = upr.p.PrimerNombre + " " + upr.p.SegundoNombre + " " + upr.p.ApellidoPaterno + " " + upr.p.ApellidoMaterno,
            //                  Correo = upr.p.Email,
            //                  Telefono = upr.p.Telefono,
            //                  Rol = upr.r.Nombre,
            //                  Estado = e.Nombre
            //              })
            //        .FirstOrDefaultAsync();
            //return datos;

        }
    }
}
