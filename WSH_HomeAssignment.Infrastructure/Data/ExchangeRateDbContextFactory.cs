using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace WSH_HomeAssignment.Infrastructure.Data
{
    public class ExchangeRateDbContextFactory : IDesignTimeDbContextFactory<ExchangeRateDbContext>
    {
        private string? ConnString { get; set; }

        public ExchangeRateDbContextFactory()
        {
             var config=new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!)
                                                  .AddJsonFile("appsettings.json")
                                                  .Build();

            ConnString = config.GetConnectionString("DefaultConnection");
        }

        public ExchangeRateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExchangeRateDbContext>();
            builder.UseSqlServer(ConnString);

            return new ExchangeRateDbContext(builder.Options);
        }
    }
}