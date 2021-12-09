using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace Core.Cross_Cutting_Concers.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //adapter pattern hali hazırda olarn şeyleri kendi sistemimize uyarlıyoruz

        //IMemoryCache Default olarak geliyor microsoft alt yapısından
        IMemoryCache _memoryCache;//Constractor burada çalışmaz Aspect Bağlılık zincirir dışında o yüzden serviceTool yazdık 
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));   // Timespan zaman aralığı
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)//bellekte böyle cache değeri var mı ?
        {
            return _memoryCache.TryGetValue(key, out _); //trygetvalue bellekte var mı yok mu ? out = bellekte böyle bir var mı yok mu 
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)// verilen pattern a göre silme işlemi yapacak
        {   //reflection ile çalışma anında eliizde bulunan nesneleri olmayanlarıda yeniden oluşturma yapacağımız yapı kısaca kodu çalışma anında oluşturma müdahale etme
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase); //pattern oluşturuldu
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();//gönderdiğim değere göre

            foreach (var key in keysToRemove) // varsa içerisine gönder
            {
                _memoryCache.Remove(key);   // onlarıda bellekten sil 
            }
        }
    }
}
