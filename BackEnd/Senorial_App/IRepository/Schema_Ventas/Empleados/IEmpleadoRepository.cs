using DBSenorialModels.Senorial;
using IRepository.Schema_Generico.CRUD;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Schema_Ventas.Empleados
{
    public interface IEmpleadoRepository : ICrudRepository<Empleado>
    {
        Task<List<EmpleadosUiRequest>> UiEmpleado();
        Task<Empleado> InsertUiEmpleado(Empleado empleado);
        Task<Empleado> UpdateUiEmpleado(Empleado empleado);
        Task<bool> DeleteUiEmpleado(int idEmpleado);
        Task<Empleado> BuscarporId(int id);
    }
}
