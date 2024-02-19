using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WSH_HomeAssignment.Infrastructure.Data
{
    public class ExchangeRateDbContextFactory : IDesignTimeDbContextFactory<ExchangeRateDbContext>
    {
        private string? ConnString { get; set; }

        public ExchangeRateDbContextFactory(IConfiguration configuration)
        {
            ConnString = configuration.GetConnectionString("DefaultConnection");
        }

        public ExchangeRateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExchangeRateDbContext>();
            builder.UseSqlServer(ConnString);

            return new ExchangeRateDbContext(builder.Options);
        }
    }
}