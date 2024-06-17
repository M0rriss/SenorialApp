using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Common
{
    public class CustomException
    {
        public string CodigoError { get; set; } = "";
        public string MensajeUsuario { get; set; } = "";

        public CustomException() : base()
        {

        }

        public CustomException(string codigoError, string mensajeUsuario)
        {
            CodigoError = codigoError;
            MensajeUsuario = mensajeUsuario;
        }

    }
}
