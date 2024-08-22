using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Estados
{
    public class EstadoLocal
    {
        public int IdEstadoMesa { get; set; }
        public string NombreEstado { get; set; } = string.Empty;

        public static readonly EstadoLocal Disponible = new()
        {
            IdEstadoMesa = 1,
            NombreEstado = "Disponible"
        };
        public static readonly EstadoLocal Ocupado = new()
        {
            IdEstadoMesa = 2,
            NombreEstado = "Ocupado"
        };
        public static readonly EstadoLocal Facturado = new()
        {
            IdEstadoMesa = 3,
            NombreEstado = "Facturado"
        };
        public static readonly List<EstadoLocal> EstadoMesasL = [Disponible,Ocupado,Facturado];
    }
}