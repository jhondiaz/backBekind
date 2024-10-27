using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testBekind.Application.Ports;
using testBekind.Application.UseCases;
using testBekind.Domain.Interfaces;
using testBekindService.DataContexts;
using testBekindService.Repository;

namespace testBekindService.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositorys(this IServiceCollection services, IConfiguration configuration)
        {

            // Configuración de MongoDB
            var connectionString = configuration.GetConnectionString("MongoDb");
            var databaseName = configuration.GetSection("DatabaseName").Value;

            services.AddSingleton<MongoContext>(sp =>
                new MongoContext(connectionString, databaseName));


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddTransient<IProductPort, ProductInteractor>();
            services.AddTransient<IUserPort, UserInteractor>();



            return services;
        }
    }
}
