using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSH_HomeAssignment.Api.Services.ExchangeRates;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.Validation
{
 
    public class ValidationDto
    {
        public int NoteMaxLength { get; set; } = DomainConstants.NoteMaxLength;
        public int UnitMin { get; set; } = DomainConstants.UnitMin;
        public double ValueMin { get; set; } = DomainConstants.ValueMin;
        public int PasswordRequiredLength { get; set; } = DomainConstants.PasswordRequiredLength;
        public DateDto DateMin { get; set; } = new DateDto();
        public int CurrencyMaxLength { get; set; }= DomainConstants.CurrencyMaxLength;
    }
}
