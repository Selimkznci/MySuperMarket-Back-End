using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cross_Cutting_Concers.Caching
{
    public interface ICacheManager
    {                                       //ne kadar duracağını duration ile veriyoruz
        //generic yapı koruyoruz hangi tip hangi tipe dönüştüreceğimizi söylüyoruz
        T Get<T>(string key);
        object Get(string key);
        void Add(string key,object value, int duration);
        bool IsAdd(string key); //cache'de var mı ?
        void Remove(string key);//Cacheden silme 
        void RemoveByPattern(string pattern); //içerisinde get olanları veya product olanları sil değişkenlik sağlayabilir ne istersek o olur :)
    }
}
