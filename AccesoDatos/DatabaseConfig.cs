using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccesoDatos
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, DbContextConfig>();

            services.AddDbContext<DbContextConfig>(options
               => options.UseSqlServer(configuration.GetConnectionString("SqlConnection"), c =>
               {
                   c.MaxBatchSize(30);
                   c.CommandTimeout(180);
               }).EnableSensitiveDataLogging());



            return services;
        }
    }
}