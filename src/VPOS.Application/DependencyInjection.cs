using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VPOS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<Products.Commands.Service.Interface.IProductService, Products.Commands.Service.ProductService>();
            services.AddTransient<Products.Queries.Service.Interface.IProductService, Products.Queries.Service.ProductService>();

            return services;
        }   
    }
}
