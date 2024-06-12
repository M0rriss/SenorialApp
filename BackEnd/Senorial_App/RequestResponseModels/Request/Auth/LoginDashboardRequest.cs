using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Auth
{
    public class LoginDashboardRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StrongPassword]
        public string Password { get; set; }
    }
    
}
