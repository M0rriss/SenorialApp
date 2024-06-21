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

        public List<EmpleadoUiRequest> UiEmpleado()
        {
            return db.Empleados
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
            (epr, s) => new EmpleadoUiRequest
            {
                IdEmpleado = epr.Empleado.IdPersona,
                Nombres = epr.Persona.PrimerNombre + " " + epr.Persona.SegundoNombre,
                Apellidos = epr.Persona.ApellidoPaterno + " " + epr.Persona.ApellidoMaterno,
                Correo = epr.Persona.Email,
                Telefono = epr.Persona.Telefono,
                Identificacion = epr.Persona.NroDocumento,
                Rol = epr.Rol.Nombre,
                Estado = epr.Rol.IdEstadoNavigation.Nombre, // Si `Estado` es una propiedad de `Rol`
                Sucursal = s.Nombre
            })
        .ToList();
        }
    }
}
