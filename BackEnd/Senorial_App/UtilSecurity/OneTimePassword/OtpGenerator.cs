using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitySecurity.OneTimePassword
{
    public class OtpGenerator
    {
        private readonly Random _random;

        public OtpGenerator()
        {
            _random = new Random();
        }

        public string GenerateOtp(int numDigits = 4)
        {
            // Generar el código OTP de longitud numDigits
            string otp = "";
            for (int i = 0; i < numDigits; i++)
            {
                otp += _random.Next(0, 10).ToString();
            }
            return otp;
        }

        public OtpData GenerateOtpData(int numDigits = 4, int expirationMinutes = 5)
        {
            // Generar el código OTP
            string otp = GenerateOtp(numDigits);

            // Calcular la fecha de expiración
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(expirationMinutes);

            // Crear el objeto OtpData
            OtpData otpData = new OtpData
            {
                Otp = otp,
                ExpirationTime = expirationTime
            };

            return otpData;
        }
    }

    public class OtpData
    {
        public string Otp { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
