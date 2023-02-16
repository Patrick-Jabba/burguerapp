using backend_burgueria.Application.Services;
using backend_burgueria.Context;
using backend_burgueria.Domain.Interfaces.Repositories;
using backend_burgueria.Infra.Data.Repositories;
using backend_burgueria.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend_burgueria.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConexaoPadrao"),
                assembly => assembly.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
