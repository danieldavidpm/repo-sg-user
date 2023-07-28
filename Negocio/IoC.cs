using AccesoDatos;
using Datos.Interfaces;
using Datos.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negocio.Authorization;
using Negocio.Interfaces;
using Negocio.Services;

namespace Negocio
{
    public static class IoC
    {
        public static IServiceCollection AddDependencyInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Config            
            services.AddDbContextConfiguration(configuration);

            // AutoMapper Config
            //services.AddDependencyInjectionAutoMapper();

            // AppService Config
            services.AddDependencyInjectionServiceNegocio();

            // Service Config
            services.AddDependencyInjectionServiceDatos();

            return services;
        }

        private static void AddDependencyInjectionServiceNegocio(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();//Authorization
            services.AddScoped<IAppN, AppN>();
            services.AddScoped<IUsuarioN, UsuarioN>();
            services.AddScoped<IRolN, RolN>();
            services.AddScoped<IUsuAppN, UsuAppN>();
            services.AddScoped<IModuloN, ModuloN>();
            services.AddScoped<IOperacionesN, OperacionesN>();
            services.AddScoped<IRolOpeN, RolOpeN>();
            services.AddScoped<IClienteN, ClienteN>();
        }

        private static void AddDependencyInjectionServiceDatos(this IServiceCollection services)
        {
            services.AddScoped<IAppD, AppD>();
            services.AddScoped<IUsuarioD, UsuarioD>();
            services.AddScoped<IRolD, RolD>();
            services.AddScoped<IUsuAppD, UsuAppD>();
            services.AddScoped<IModuloD, ModuloD>();
            services.AddScoped<IOperacionesD, OperacionesD>();
            services.AddScoped<IRolOpeD, RolOpeD>();
            services.AddScoped<IClienteD, ClienteD>();
        }

    }
}