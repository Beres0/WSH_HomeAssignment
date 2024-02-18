using System.ComponentModel;
using System.Globalization;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates
{
    public class DateDtoConverter:TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            if (typeof(string) == sourceType)
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var str = value as string;
            if (DateOnly.TryParseExact(str, "yyyy-MM-dd", out DateOnly result))
            {
                return result.ToDto();
            }


            return new DateDto();
        }

     
    }
}
