﻿using System.ComponentModel.DataAnnotations;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public class DailyExchangeRatesDto
    {
        public DateDto Date { get; set; }
        public Dictionary<string, ExchangeRateDto> ExchangeRates { get; set; } = new();
    }
}