using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{

    public interface IDailyExchangeRateRepository
    {
        Task<DailyExchangeRates> CreateAsync(DailyExchangeRates exchangeRates, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(DateTime date, CancellationToken cancellationToken = default);
        Task<DailyExchangeRates?> GetAsync(DateTime date, CancellationToken cancellationToken = default);
        Task<DailyExchangeRates?> GetLastAsync(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
