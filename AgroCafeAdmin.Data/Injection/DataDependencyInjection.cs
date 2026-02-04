using AgroCafeAdmin.Data.Repository;
using AgroCafeAdmin.Data.Repository.Productores;
using AgroCafeAdmin.Data.Repository.Seguridad;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Data.Injection
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // ... configuración del DbContext ...

            // Registro de la clase genérica (si la sigues usando)
            //services.AddScoped<GenericRepository>();

            // Registro directo de repositorios específicos
            services.AddScoped<IAutorizacionRepository, AutorizacionRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IProductorRepository, ProductorRepository>();
            services.AddScoped<IFincaRepository, FincaRepository>();
            //services.AddScoped<LoteRepository>(); // Ejemplo de otro repo

            return services;
        }
    }
}
