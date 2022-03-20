using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VPOS.Application.Common.Interfaces;
using VPOS.Domain.Repositories;
using VPOS.Infrastructure.Persistence;
using VPOS.Infrastructure.Repositories;

namespace VPOS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

            return services;
        }
    }
}
