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
        public List<EmpleadoUiRequest> UiEmpleado();
    }
}
