using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitySecurity.Validations;

namespace RequestResponseModels.Request.Auth
{
    public class LoginUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StrongPassword, PasswordPropertyText]
        public string Password { get; set; }
    }
    
}
