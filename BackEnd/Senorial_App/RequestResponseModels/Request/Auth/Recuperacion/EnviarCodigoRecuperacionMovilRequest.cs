using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Auth.Recuperacion
{
    public class EnviarCodigoRecuperacionMovilRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
