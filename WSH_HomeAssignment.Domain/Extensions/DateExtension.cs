using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Domain.Extensions
{
    public static class DateExtension
    {
        public static DateTime TrimTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
      
    }
}
