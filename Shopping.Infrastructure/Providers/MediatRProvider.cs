using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shopping.Infrastructure.Providers
{
    public static class MediatRProvider
    {
        public static IServiceCollection AddMediatR(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return serviceCollection;
        }
    }
}
