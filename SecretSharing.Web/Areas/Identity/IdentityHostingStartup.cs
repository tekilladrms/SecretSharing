﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SecretSharing.Web.Areas.Identity.IdentityHostingStartup))]
namespace SecretSharing.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}