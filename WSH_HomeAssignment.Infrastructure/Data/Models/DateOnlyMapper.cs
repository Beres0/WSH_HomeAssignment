﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    internal static class DateOnlyMapper
    {
        public static DateTime ToDateTime(this DateOnly date)
        {
            return date.ToDateTime(TimeOnly.MinValue);
        }
        public static DateOnly ToDateOnly(this DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
    }
}
