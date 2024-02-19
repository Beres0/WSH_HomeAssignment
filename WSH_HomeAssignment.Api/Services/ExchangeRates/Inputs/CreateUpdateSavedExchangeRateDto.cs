using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Inputs
{
    public class CreateUpdateSavedExchangeRateDto
    {
        [StringLength(DomainConstants.NoteMaxLength)]
        public string? Note { get; set; }
    }
}