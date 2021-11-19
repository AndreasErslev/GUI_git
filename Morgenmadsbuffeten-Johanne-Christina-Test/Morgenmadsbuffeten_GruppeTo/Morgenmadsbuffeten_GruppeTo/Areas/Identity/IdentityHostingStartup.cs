using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Morgenmadsbuffeten_GruppeTo.Data;

[assembly: HostingStartup(typeof(Morgenmadsbuffeten_GruppeTo.Areas.Identity.IdentityHostingStartup))]
namespace Morgenmadsbuffeten_GruppeTo.Areas.Identity
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