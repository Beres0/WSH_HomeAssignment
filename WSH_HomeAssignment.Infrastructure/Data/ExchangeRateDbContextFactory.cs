using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace WSH_HomeAssignment.Infrastructure.Data
{
    public class ExchangeRateDbContextFactory : IDesignTimeDbContextFactory<ExchangeRateDbContext>
    {
        public ExchangeRateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExchangeRateDbContext>();
            builder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=exchange-rates;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ExchangeRateDbContext(builder.Options);
        }
    }
}
