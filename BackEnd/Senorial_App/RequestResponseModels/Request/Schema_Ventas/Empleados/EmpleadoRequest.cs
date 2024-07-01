using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Schema_Ventas.Empleados
{
    public class EmpleadoRequest
    {
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public int IdPersona { get; set; }
        public int IdSucursal { get; set; }
    }
    public class EmpleadosUiRequest
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string Sucursal { get; set; } = null;



    }
    public class EmpleadoUpdateUiRequest
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [DocumentType]
        public string Identificacion { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string Sucursal { get; set; } = null;



    }
}
//SELECT CONCAT(p.primer_nombre, ' ', p.segundo_nombre) AS Nombres,
//       CONCAT(p.apellido_paterno, ' ', p.apellido_materno) AS Apellidos,
//       p. email AS Correo,
//       p.telefono AS Telefono,
//       p.nro_Documento as Identificacion,
//       r.nombre As Rol,
//       es.nombre as Estado,
//       s.nombre as Sucursal
//FROM Ventas.empleado e
//	INNER JOIN Usuarios.personas p ON e.id_persona = p.id_persona
//	INNER JOIN Usuarios.roles r ON e.id_rol = r.id_rol
//	INNER JOIN Generico.estado es ON r.id_estado = es.id_estado
//	INNER JOIN Generico.sucursal s ON e.id_sucursal = s.id_sucursal