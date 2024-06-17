using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.SMS
{
    public interface ISmsService
    {
        Task EnviarSms(string telefono, string mensaje);
    }
}
