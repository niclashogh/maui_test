using maui_test.Services;
using System.Globalization;

namespace maui_test.Pages.Converters
{
    public class UnixToDateConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (long.TryParse(value.ToString(), out long unix))
            {
                DateTimeOffset dateTime = DataConverters.UnixTimeStapToDataTimeOffset(unix);
                return dateTime.ToString("ddd, dd MMM, yyyy HH:mm 'GMT'", CultureInfo.InvariantCulture);
            }
            else return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
