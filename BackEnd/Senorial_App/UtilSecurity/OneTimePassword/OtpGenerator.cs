using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitySecurity.OneTimePassword
{
    public class OtpGenerator
    {

        public  Random random = new Random();

        public string GenerateOtp(int numDigits = 4)
        {
            string codigo = "";

            for (int i = 0; i < numDigits; i++)
            {
                codigo += random.Next(0, 10).ToString();
            }

            return codigo;
        }

    }
}
