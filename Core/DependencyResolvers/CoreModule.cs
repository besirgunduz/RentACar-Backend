using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddMemoryCache(); //hazır bir instance oluşturur.
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //başka bir cache yapısına geçince değiştir
        }
    }
}
