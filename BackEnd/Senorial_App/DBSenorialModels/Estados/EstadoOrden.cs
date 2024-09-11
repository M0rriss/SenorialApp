using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Estados
{
    public class EstadoOrden
    {
        public int IdEstadoOrden { get; set; }
        public string NombreEstado { get; set; } = string.Empty;

        public static readonly EstadoOrden Preparado = new()
        {
            IdEstadoOrden = 1,
            NombreEstado = "Preparado"
        };
        public static readonly EstadoOrden Pendiente = new()
        {
            IdEstadoOrden = 2,
            NombreEstado = "Pendiente"
        };
        public static readonly EstadoOrden Facturado = new()
        {
            IdEstadoOrden = 3,
            NombreEstado = "Facturado"
        };
        public static readonly EstadoOrden Cancelado = new()
        {
            IdEstadoOrden = 4,
            NombreEstado = "Cancelado"
        };
        public static readonly EstadoOrden Editar = new()
        {
            IdEstadoOrden = 5,
            NombreEstado = "Reaperturar"
        };
        public static readonly List<EstadoOrden> EstadoOrdenes = [Preparado, Pendiente, Facturado, Cancelado,Editar ];
    }
}
