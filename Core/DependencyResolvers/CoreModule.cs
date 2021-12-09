using Core.Cross_Cutting_Concers.Caching;
using Core.Cross_Cutting_Concers.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //MemoryCacheManager    //
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//MemoryCacheManager    
            //serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();   Redise geçersek 20.satır silinir redis gelir addmemoryCache silinir
        }
    }
}
