using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>()/*(o =>
            {
                string connectionString = configuration.GetConnectionString("Default");
                o.UseSqlServer(connectionString);
            })*/;
            services.AddTransient<PostService>();
            return services;
        }

    }
}
