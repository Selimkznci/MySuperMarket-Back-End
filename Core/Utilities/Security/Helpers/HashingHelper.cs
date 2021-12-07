using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Helpers
{
    public class HashingHelper
    {
        //Gönderilen Passwordun Hash ini ve Salt ını oluşturacak //out boş gelen değeri dolu çekilde gönderiyor ref
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {               //HMACSHA512 algoritmasından yararlanarak sifre döndüreceğiz
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;  //Her Kullanıcı için Key oluşturduk 
                                                //Stringin byte'ını alabilmek için Encoding.UTF8 kullandık
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //'Doğrulama' neyi ? : passwordHash i doğrulama
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)//Hesaplanan hash değerlerini tek tek dolaş
                {
                    if (computedHash[i] != passwordHash[i])//eğer eşit değilse 
                    {
                        return false;   //false döndür
                    }
                }
                return true; // Eşleşirse doğrudur :)
            }
        }
    }
}
