using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecretSharing.Application.Abstractions;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;

namespace SecretSharing.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.ClaimsIdentity.RoleClaimType = "MyRoleClaimType";

                    
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            return services;
        }
    }
}
