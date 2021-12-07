using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption
{
    public class SigningCredentialsHelper
    {
        //'Signing=İmzalama' = Token servislerimizi web api'de jwt tokenlarının oluşturulması için kullanırız 
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //Bu anahtarı kullan algoritma olarakta şifreleme olarakta HmacSha512Signature
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
