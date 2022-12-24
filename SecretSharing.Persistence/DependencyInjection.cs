using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecretSharing.Application.Users;
using SecretSharing.Domain.Repositories;

namespace SecretSharing.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(connectionString)));

            services.AddDbContext<IdentityAppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(connectionString)));

            //var builder = services.AddIdentityCore<ApplicationUser>();
            //var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);

            //identityBuilder.AddEntityFrameworkStores<IdentityAppDbContext>();
            //identityBuilder.AddSignInManager<SignInManager<ApplicationUser>>();

            return services;
        }
    }
}
