using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.ApisPeru
{
    public class DniResponse
    {
        private bool _success;
        private string _dni;
        private string _nombres;
        private string _apellidoPaterno;
        private string _apellidoMaterno;
        private string _codVerifica;

        public bool Success { get => _success; set => _success = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string ApellidoPaterno { get => _apellidoPaterno; set => _apellidoPaterno = value; }
        public string ApellidoMaterno { get => _apellidoMaterno; set => _apellidoMaterno = value; }
        public string CodVerifica { get => _codVerifica; set => _codVerifica = value; }

        public DniResponse()
        {
            _success = false;
            _dni = string.Empty;
            _nombres = string.Empty;
            _apellidoPaterno = string.Empty;
            _apellidoMaterno = string.Empty;
            _codVerifica = string.Empty;
        }
    }
}
