
using Microsoft.EntityFrameworkCore;
using WSH_HomeAssignment.Api.Background;
using WSH_HomeAssignment.Domain.ExchangeRatesServices;
using WSH_HomeAssignment.Domain.ExchangeServices;
using WSH_HomeAssignment.Domain.Repositories;
using WSH_HomeAssignment.Infrastructure.Data;
using WSH_HomeAssignment.Infrastructure.Data.Repositories;
using WSH_HomeAssignment.Infrastructure.ExchangeRatesService;

namespace WSH_HomeAssignment.Api
{
    public static class ServiceConfigurationExtension
    {

        private static void AddRepositories(IServiceCollection serviceCollection, WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ExchangeRateDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            serviceCollection.AddTransient<IDailyExchangeRateRepository, DailyExchangeRateRepository>();
            serviceCollection.AddTransient<ISavedExchangeRateRepository, SavedExchangeRateRepository>();
        }
        private static void AddExchangeRateServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<DailyExchangeRatesXmlParser>();
            serviceCollection.AddTransient<MNBArfolyamServiceSoapClient>();
            serviceCollection.AddTransient<IExternalExchangeRatesService, MNBExchangeRatesService>();
            serviceCollection.AddTransient<IExchangeRatesService, CachedExchangeRatesService>();
            serviceCollection.AddHostedService<CurrentExchangeRatesRequester>();
        }
        public static IServiceCollection AddAppServices(this IServiceCollection serviceCollection, WebApplicationBuilder builder)
        {
            AddRepositories(serviceCollection, builder);
            AddExchangeRateServices(serviceCollection);
            return serviceCollection;
        }

    }
}