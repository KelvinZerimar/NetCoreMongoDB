using Application.App.Interfaces;
using Application.App.Services;
using Domain.Interfaces;
using Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Application - Domain
            services.AddScoped<ISalesAppService, SalesAppService>();
            //Domain - Data
            services.AddScoped<ISaleRepository, SalesRepository>();
        }
    }
}
