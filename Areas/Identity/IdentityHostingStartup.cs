using System;
using WebCalendar.Data;
using WebCalendar.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WebCalendar.Areas.Identity.IdentityHostingStartup))]
namespace WebCalendar.Areas.Identity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Hosting.IHostingStartup" />
    public class IdentityHostingStartup : IHostingStartup
    {
        /// <summary>
        /// Configure the <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.
        /// </summary>
        /// <param name="builder"></param>
        /// <remarks>
        /// Configure is intended to be called before user code, allowing a user to overwrite any changes made.
        /// </remarks>
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
