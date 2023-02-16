using backend_burgueria.Context;
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

            return services;
        }
    }
}
