using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace WSH_HomeAssignment.Infrastructure.Data
{
    public class ExchangeRateDbContextFactory : IDesignTimeDbContextFactory<ExchangeRateDbContext>
    {
        public ExchangeRateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExchangeRateDbContext>();
            builder.UseSqlServer("Server=(LocalDb)\\\\MSSQLLocalDB;Database=ExchangeRates;Trusted_Connection=True;TrustServerCertificate=True");

            return new ExchangeRateDbContext(builder.Options);
        }
    }
}
