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