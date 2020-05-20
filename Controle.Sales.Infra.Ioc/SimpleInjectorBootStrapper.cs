using Controle.Sales.Application.Interfaces;
using Controle.Sales.Application.Services;
using Controle.Sales.Domain.Interfaces;
using Controle.Sales.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Controle.Sales.Infra.Ioc
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
