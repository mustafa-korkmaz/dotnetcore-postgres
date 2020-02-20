using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BoilerplateDotnetCorePostgres.Configuration.Jwt
{
    public class JwtTokenConstants
    {
        public static SecurityKey IssuerSigningKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GetCryptoSecurityKey()));
            }
        }

        public static SigningCredentials SigningCredentials
        {
            get
            {
                return new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256);
            }
        }

        public static TimeSpan TokenExpirationTime
        {
            get
            {
                return TimeSpan.FromDays(30);
            }
        }

        public static string Issuer
        {
            get
            {
                return "Issuer";
            }
        }

        public static string Audience
        {
            get
            {
                return "Audience";
            }
        }



        private static string GetCryptoSecurityKey()
        {
            var securityKey = "19ASREAFATSUMZAMKROK07";
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(securityKey));
                return Encoding.ASCII.GetString(result);
            }
        }
    }
}
