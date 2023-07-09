using Blog.Business.Services;
using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Blog.Business
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                string connectionString = configuration.GetConnectionString("Default");
                o.UseSqlServer(connectionString);
                //o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddTransient<PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<PageService>();
            services.AddTransient<SettingService>();
            services.AddTransient<IUserService, UserService>();
            //services.AddScoped<PostService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<PageService>();
            //services.AddScoped<SettingService>();
            //services.AddScoped<IUserService, UserService>();

            return services;
        }
        public static void EnsureDeletedAndCreated(IServiceScope scope)
        {
			// Veritabanı servisine erişim sağlar.
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			// Veritabanını sil
			context.Database.EnsureDeleted();
			// Veritabanını oluşturur
			context.Database.EnsureCreated();

			DbSeeder.Seed(context);
		}
    }
}
