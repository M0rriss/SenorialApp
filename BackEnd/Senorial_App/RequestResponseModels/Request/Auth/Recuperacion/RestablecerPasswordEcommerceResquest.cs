using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Auth.Recuperacion
{
    public class RestablecerPasswordEcommerceRequest
    {
        public string Email { get; set; }
        public string CodigoOtp { get; set; }
        public string NuevoPassword { get; set; }
        public string ConfirmarContraseña { get; set; }
    }
}
