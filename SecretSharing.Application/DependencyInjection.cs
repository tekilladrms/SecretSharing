using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SecretSharing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(AssemblyReference.Assembly);

            services.AddAutoMapper(new[] { Assembly.GetExecutingAssembly() });

            return services;
        }
    }
}
