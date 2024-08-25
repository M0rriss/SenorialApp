using DBSenorialModels.Senorial;
using IRepository.Schema_Ventas.Empleados;
using Microsoft.EntityFrameworkCore;
using Repository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Schema_Ventas.Empleados
{
    public class EmpleadoRepository : CrudRepository<Empleado>, IEmpleadoRepository
    {
        public Task<GenericFilterResponse<Empleado>> GetByFilterAsync(GenericFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmpleadosUiRequest>> UiEmpleado()
        {
            return await db.Empleados
        .Join(db.Personas,
            e => e.IdPersona,
            p => p.IdPersona,
            (e, p) => new { Empleado = e, Persona = p })
        .Join(db.Roles,
            ep => ep.Empleado.IdRol,
            r => r.IdRol,
            (ep, r) => new { ep.Empleado, ep.Persona, Rol = r })
        .Join(db.Sucursals,
            epr => epr.Empleado.IdSucursal,
            s => s.IdSucursal,
            (epr, s) => new EmpleadosUiRequest
            {
                IdEmpleado = epr.Empleado.IdPersona,
                Nombres = epr.Persona.PrimerNombre + " " + epr.Persona.SegundoNombre,
                Apellidos = epr.Persona.ApellidoPaterno + " " + epr.Persona.ApellidoMaterno,
                Correo = epr.Persona.Email,
                Telefono = epr.Persona.Telefono,
                Identificacion = epr.Persona.NroDocumento,
                Rol = epr.Rol.Nombre,
                Estado = epr.Empleado.Estado.HasValue
                            ? (epr.Empleado.Estado.Value ? "Activo" : "Inactivo")
                            : "Activo", // Manejo explícito de nullables
                
            })
        .ToListAsync();
        }
        public async Task<Empleado> InsertUiEmpleado(Empleado empleado)
        {
            await dbset.AddAsync(empleado);
            await db.SaveChangesAsync();
            return empleado;
        }
        public async Task<Empleado> UpdateUiEmpleado(Empleado empleado)
        {
            dbset.Update(empleado);
            await db.SaveChangesAsync();
            return empleado;
        }
        public async Task<bool> DeleteUiEmpleado(int idEmpleado)
        {
            var empleado = await db.Empleados.FindAsync(idEmpleado);
            if(empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "Empleado no encontrado");
            }
            db.Remove(empleado);
            await db.SaveChangesAsync();
            return true;    
        }
        public Empleado BuscarporId(int id)
        {
            var empleado = dbset. Where(e => e.IdEmpleado == id).FirstOrDefault();
            return empleado;
        }
       
    }
}
