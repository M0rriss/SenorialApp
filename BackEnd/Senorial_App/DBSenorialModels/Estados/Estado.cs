using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Estados
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public static readonly Estado Activo = new (){
            IdEstado = 1,
            Nombre = "Activo",
        };

        public static readonly Estado Inactivo = new() {
            IdEstado = 2,
            Nombre = "Inactivo",
        };

        public static readonly List<Estado> Estados = [
            Activo,
            Inactivo,
            ];
    }
}
