using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates
{
    [TypeConverter(typeof(DateDtoConverter))]
    public class DateDto
    {
        public int Year { get; set; } = DomainConstants.DateMin.Year;

        [Range(1, 12)]
        public int Month { get; set; } = DomainConstants.DateMin.Month;

        [Range(1, 31)]
        public int Day { get; set; } = DomainConstants.DateMin.Day;
    }
}