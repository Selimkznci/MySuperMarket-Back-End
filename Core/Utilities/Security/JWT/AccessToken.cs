using System;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }//İstek Üzerine Token VEriyoruz
        public DateTime Expiration { get; set; }//Oluşturulan tokenin Bitiş Tarihi
    }
}
