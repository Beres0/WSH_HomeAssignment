using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WSH_HomeAssignment.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using WSH_HomeAssignment.Domain.Entities;
using System.Reflection;

namespace WSH_HomeAssignment.Infrastructure.Data
{

    public class ExchangeRateDbContext:IdentityDbContext<IdentityUser>
    {
        public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options) : base(options)
        {
        }

        internal virtual DbSet<ExchangeRateRecord> ExchangeRates { get; set; } = null!;
        internal virtual DbSet<SavedExchangeRateRecord> SavedExchangeRates { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
