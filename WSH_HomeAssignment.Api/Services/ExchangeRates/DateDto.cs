using System.ComponentModel.DataAnnotations;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates
{
    public class DateDto
    {
        public int Year { get; set; }
        [Range(1,12)]
        public int Month { get; set; }
        [Range(1,31)]
        public int Day { get; set; }
    }
}
