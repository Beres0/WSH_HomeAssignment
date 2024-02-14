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

namespace WSH_HomeAssignment.Infrastructure.Data
{
    public class ExchangeRateDbContext:IdentityDbContext<IdentityUser>
    {
        public ExchangeRateDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ExchangeRateRecord> ExchangeRates { get; set; } = null!;
        public virtual DbSet<SavedExchangeRateRecord> SavedExchangeRates { get; set; } = null!;
        
    }
}
