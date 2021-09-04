using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extension
{
    public static class ServiceCollectionExtensions
    {
        //ekleyeceğimiz bütün injectionları bir arada toplayacağımız bir yapıdır.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
