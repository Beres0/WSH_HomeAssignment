using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WSH_HomeAssignment.Infrastructure.Data.Models;

namespace WSH_HomeAssignment.Infrastructure.Data
{
    public class ExchangeRateDbContext : IdentityDbContext<IdentityUser>
    {
        public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options) : base(options)
        {
        }

        internal virtual DbSet<ExchangeRateRecord> ExchangeRates { get; set; } = null!;
        internal virtual DbSet<SavedExchangeRateRecord> SavedExchangeRates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}