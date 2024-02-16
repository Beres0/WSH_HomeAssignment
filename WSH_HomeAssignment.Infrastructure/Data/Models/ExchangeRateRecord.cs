using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    internal class ExchangeRateRecord
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; } = null!;
        public int Unit { get; set; }
        public double Value { get; set; }
   
    }
    internal class ExchangeRateRecordConfiguration : IEntityTypeConfiguration<ExchangeRateRecord>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateRecord> builder)
        {
            builder.HasKey(nameof(ExchangeRateRecord.Date),nameof(ExchangeRateRecord.Currency));
            builder.Property(r => r.Currency).HasMaxLength(DomainConstants.CurrencyMaxLength);
        }
    }
}
