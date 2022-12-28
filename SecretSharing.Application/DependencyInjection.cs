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
using Amazon.S3;
using Microsoft.Extensions.Configuration;

namespace SecretSharing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(AssemblyReference.Assembly);
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });


            services.AddAWSService<IAmazonS3>(configuration.GetAWSOptions());
            services.AddAutoMapper(new[] { Assembly.GetExecutingAssembly() });
            
            return services;
        }
    }
}
