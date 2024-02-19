using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    internal class SavedExchangeRateRecord
    {
        public string UserId { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Note { get; set; }

        public virtual ExchangeRateRecord ExchangeRate { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;
    }

    internal class SavedExchangeRateRecordConfiguration : IEntityTypeConfiguration<SavedExchangeRateRecord>
    {
        public void Configure(EntityTypeBuilder<SavedExchangeRateRecord> builder)
        {
            builder.HasKey(nameof(SavedExchangeRateRecord.Date), nameof(SavedExchangeRateRecord.Currency), nameof(SavedExchangeRate.UserId));
            builder.Property(r => r.Currency).HasMaxLength(DomainConstants.CurrencyMaxLength);
            builder.Property(r => r.Note).HasMaxLength(DomainConstants.NoteMaxLength);

            builder.HasOne(nameof(SavedExchangeRateRecord.ExchangeRate))
                   .WithMany()
                   .HasForeignKey(nameof(SavedExchangeRateRecord.Date), nameof(SavedExchangeRateRecord.Currency));

            builder.HasOne(nameof(SavedExchangeRateRecord.User))
                   .WithMany()
                   .HasForeignKey(nameof(SavedExchangeRateRecord.UserId));
        }
    }
}