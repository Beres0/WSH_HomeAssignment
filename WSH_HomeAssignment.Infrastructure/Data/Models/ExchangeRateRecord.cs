using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    public class ExchangeRateRecord
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; } = null!;
        public int Unit { get; set; }
        public double Value { get; set; }
        public ExchangeRate ToExchangeRate()
        {
            return new ExchangeRate(Currency, Unit, Value);
        }
    }
    public class ExchangeRateRecordConfiguration : IEntityTypeConfiguration<ExchangeRateRecord>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateRecord> builder)
        {
            builder.HasKey(r => new { r.Date,r.Currency});
            builder.Property(r => r.Currency).HasMaxLength(DomainConstants.CurrencyMaxLength);
        }
    }
}
