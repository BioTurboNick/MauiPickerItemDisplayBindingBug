using System.Globalization;

namespace MauiPickerItemDisplayBindingBug;

public class IntToPowerConverter :
    IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (targetType != typeof(string))
            return new object();

        return value switch
        {
            int intValue => FormatHelpers.ToPowerOfTen(intValue, culture),
            _            => string.Empty
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}
