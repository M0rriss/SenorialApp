using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Gmail
{
    public interface ISendEmailSmtp
    {
        Task SendEmail(string destino);
    }
}
