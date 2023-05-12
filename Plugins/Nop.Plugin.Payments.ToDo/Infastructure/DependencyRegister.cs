using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Web.Models;


namespace Nop.Plugin.Other.ProductViewTracker.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring services on application startup
    /// </summary>
    public class NopStartup : INopStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NopCommerceContext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-5HU625C7;Initial Catalog=NopCommerce;Integrated Security=True;TrustServerCertificate=True"));
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {

        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 3000;
    }
}