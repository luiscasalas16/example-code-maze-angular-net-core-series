using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repository;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) 
        {
            services.AddSingleton<ILoggerManager, LoggerManager>(); 
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultContext");
            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services) 
        { 
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>(); 
        }
    }
}
