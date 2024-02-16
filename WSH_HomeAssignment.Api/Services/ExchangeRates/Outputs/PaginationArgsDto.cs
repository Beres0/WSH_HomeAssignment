using System.Runtime.CompilerServices;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public class PaginationArgsDto : IPaginationArgs
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
