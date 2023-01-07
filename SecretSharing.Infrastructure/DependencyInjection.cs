using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecretSharing.Application.Abstractions;
using SecretSharing.Infrastructure.Authentication;

namespace SecretSharing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtProvider, JwtProvider>();

            

            return services;
        }
    }
}
