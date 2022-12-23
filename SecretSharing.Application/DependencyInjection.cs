using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;

namespace SecretSharing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(new[] { Assembly.GetExecutingAssembly() });
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddAutoMapper(new[] { Assembly.GetExecutingAssembly() });
            
            return services;
        }
    }
}
